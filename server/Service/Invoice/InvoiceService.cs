using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO;
using server.DTO.Voucher;
using server.middlewares;
using server.Models;

namespace server.Service;

public class InvoiceService : IInvoiceService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly AuthJwtToken _authJwtToken;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public InvoiceService(IMapper mapper, DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _authJwtToken = authJwtToken;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ServiceResponse<GetInvoiceDTO>> Create(AddInvoiceDTO addInvoiceDTO)
    {
        var serviceResponse = new ServiceResponse<GetInvoiceDTO>();
        if (addInvoiceDTO.ListProduct.Count == 0)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Thao tác không thành công";
            return serviceResponse;
        }
        var tokenCustomer = _httpContextAccessor.HttpContext.Request.Cookies["customer"];
        var customerID = _authJwtToken.ValidateToken(tokenCustomer);
        var customerInfo = await _dataContext.Customers.SingleOrDefaultAsync(x => x.CustomerID == customerID.UserID);

        if (customerInfo is null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Người dùng chưa đăng nhập";
            return serviceResponse;
        }
        var newInvoice = _mapper.Map<Invoice>(addInvoiceDTO);

        var statusInvoice = await _dataContext.SystemStatus.FirstOrDefaultAsync(x => x.StatusID == 3);

        //Thêm vào bảng detail
        var listProduct = new List<InvoiceDetail>();
        float subTotal = 0;
        int totalQuantity = 0;
        foreach (var item in addInvoiceDTO.ListProduct)
        {
            
            var Product = await _dataContext.Products.FirstOrDefaultAsync(x => x.ProductID == item.ProductID);
            if (Product is null || (Product.import_count - Product.sold_count ) <= 0)
            {
                throw new Exception("Sản phẩm không hợp lệ");
            }
            var invoiceDetail = new InvoiceDetail
            {
                Quantity = item.Quantity,
                SubTotal = item.Quantity * Product.SellPrice,
                Productid = Product,
                Invoiceid = newInvoice
            };
            subTotal += invoiceDetail.SubTotal;
            totalQuantity += invoiceDetail.Quantity;
            listProduct.Add(invoiceDetail);
        }
        //check voucher còn hạn,còn số lượng
        if (addInvoiceDTO.VoucherCode != null)
        {
            
            var voucher = await _dataContext.Vouchers.Include(x=>x.VoucherStatus).SingleOrDefaultAsync(x => x.VoucherCode == addInvoiceDTO.VoucherCode);
            if (voucher.QuantityRemain <= 0 || voucher.VoucherStatus.StatusID == 2)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Voucher không hợp lệ";
                return serviceResponse;
            }
            newInvoice.Voucher = voucher;
            newInvoice.TotalDiscount = subTotal * voucher.Discount;
            voucher.QuantityRemain--;
        }
        newInvoice.StatusInvoice = statusInvoice;
        newInvoice.CreatedAt = DateTime.Now;
        newInvoice.CustomerId = customerInfo;
        newInvoice.SubTotal = subTotal; 
        newInvoice.TotalProduct = totalQuantity;


        _dataContext.Invoices.Add(newInvoice);
        _dataContext.InvoiceDetails.AddRange(listProduct);
        await _dataContext.SaveChangesAsync();

        serviceResponse.Success = true;
        serviceResponse.Message = "Đặt hàng thành công";
        return serviceResponse;


    }

    public async Task<ServiceResponse<GetInvoiceDTO>> Update(string status, int id)
    {
        var serviceResponse = new ServiceResponse<GetInvoiceDTO>();
        var invoice = await _dataContext.Invoices.FirstOrDefaultAsync(x => x.InvoiceID == id);

        if (invoice is null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "";
            return serviceResponse;
        }
        var tokenUser = _httpContextAccessor.HttpContext.Request.Cookies["user"];
        var userID = _authJwtToken.ValidateToken(tokenUser);
        var userInfo = await _dataContext.Users.SingleOrDefaultAsync(x => x.UserID == userID.UserID);

        if (userInfo is null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Người dùng chưa đăng nhập";
            return serviceResponse;
        }
        invoice.UserId = userInfo;
        if (status == "reject")
        {
            var newStatus = await _dataContext.SystemStatus.FirstOrDefaultAsync(x => x.StatusID == 5);
            invoice.StatusInvoice = newStatus;
            
        }
        else if (status == "accept")
        {
            var newStatus = await _dataContext.SystemStatus.FirstOrDefaultAsync(x => x.StatusID == 4);
            var listProduct = await _dataContext.InvoiceDetails.Include(x=>x.Productid).Where(x => x.Invoiceid.InvoiceID == invoice.InvoiceID).ToListAsync();
            foreach (var item in listProduct)
            {
                Console.WriteLine("proid " + item.Productid.ProductID);
                var product = await _dataContext.Products.FirstOrDefaultAsync(x => x.ProductID == item.Productid.ProductID);

                int countRemain = (product?.import_count ?? 0) - (product?.sold_count ?? 0);
                if(countRemain < item.Quantity)
                {
                    serviceResponse.Message = "Số lượng sản phẩm còn lại trong kho không đủ";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                product.sold_count = (product.sold_count ?? 0) + item.Quantity;
            }

            invoice.StatusInvoice = newStatus;
            
        }
        else
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Thao tác thất bại";
            return serviceResponse;
        }

        await _dataContext.SaveChangesAsync();
        serviceResponse.Success = true;
        serviceResponse.Message = "Cập nhật đơn hàng thành công";
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetInvoiceDTO>>> GetAll(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetInvoiceDTO>>();
        List<Invoice> invoiceList;

        if (id == 3)
        {
            invoiceList = await _dataContext.Invoices
                .Where(x => x.StatusInvoice.StatusID == id)
                .Include(x => x.CustomerId)
                .Include(x => x.StatusInvoice)
                .Include(x => x.UserId)
                .ToListAsync();
        }
        else
        {
            invoiceList = await _dataContext.Invoices
                .Where(x => x.StatusInvoice.StatusID != 3)
                .Include(x => x.CustomerId)
                .Include(x => x.StatusInvoice)
                .Include(x => x.UserId)
                .ToListAsync();
        }
        var result = invoiceList.Select(x => new GetInvoiceDTO
        {
            InvoiceID = x.InvoiceID,
            Customer = x.CustomerId.DisplayName,
            CreateAt = x.CreatedAt.ToString("dd/MM/yyyy"),
            Quantity = x.TotalProduct,
            Note = x.Note,
           // StatusInvoice = x.StatusInvoice.StatusName,
            UserName = x?.UserId?.DisplayName ?? "",
            SubTotal =x.SubTotal
        }).ToList();
        serviceResponse.Data = result;
        serviceResponse.Success = true;
        return serviceResponse;
    }


    public async Task<ServiceResponse<InvoiceDTO>> GetInvoiceById(int id)
    {
        var serviceResponse = new ServiceResponse<InvoiceDTO>();
        var invoice = await _dataContext.Invoices.Include(x => x.CustomerId).Include(x => x.StatusInvoice).Include(x => x.UserId).Include(x=>x.Voucher).FirstOrDefaultAsync(x => x.InvoiceID == id);
        if (invoice is null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Không tìm thấy hóa đơn";
            return serviceResponse;
        }
        var productList = await _dataContext.InvoiceDetails.Include(x => x.Productid).Where(x => x.Invoiceid == invoice).ToListAsync();
        var result = new InvoiceDTO
        {
            InvoiceID = invoice.InvoiceID,
            Customer = invoice.CustomerId.DisplayName,
            CreateAt = invoice.CreatedAt.ToString("dd/MM/yyyy"),
            Quantity = invoice.TotalProduct,
            Note = invoice.Note,
            StatusInvoice = invoice.StatusInvoice.StatusID,
            VoucherCode = invoice.Voucher?.VoucherCode ?? "",
            TotalDiscount=invoice.TotalDiscount,
            Location = invoice.Location,
            Subtotal = invoice.SubTotal,
            UserName = invoice?.UserId?.DisplayName ?? "",
        };
        result.InvoiceDetail = productList.Select(x => new InvoiceDetailDTO
        {
            ProductID = x.Productid.ProductID,
            ProductName = x.Productid.ProductName,
            Quantity = x.Quantity,
            Price=x.Productid.SellPrice,
            SubTotal = x.SubTotal,

            URLImage = _dataContext.Images.Where(image => image.ImagesType == "Product").Where(image => image.Product.ProductID == x.Productid.ProductID).Select(image => image.ImagesUrl).FirstOrDefault().ToString()
        }).ToList();

        serviceResponse.Data = result;
        serviceResponse.Success = true;
        return serviceResponse;
    }

}