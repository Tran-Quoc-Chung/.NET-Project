using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Org.BouncyCastle.Crypto.Paddings;
using server.Data;
using server.DTO;
using server.middlewares;
using server.Models;
using server.Service.Products;

namespace server.Service;

public class InventoryService : IInventoryService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly AuthJwtToken _authJwtToken;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public InventoryService(IMapper mapper, DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor, Cloudinary cloudinary)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _authJwtToken = authJwtToken;
        _httpContextAccessor = httpContextAccessor;
    }


    public async Task<ServiceResponse<GetInventoryDTO>> Create(AddInventoryDTO addInventoryDTO)
    {
        var serviceResponse = new ServiceResponse<GetInventoryDTO>();

        var token = _httpContextAccessor.HttpContext.Request.Cookies["user"];
        var userID = _authJwtToken.ValidateToken(token);
        var userInfo = await _dataContext.Users.SingleOrDefaultAsync(x => x.UserID == userID.UserID);
        var partnerInfo = await _dataContext.Partners.SingleOrDefaultAsync(x => x.PartnerId == addInventoryDTO.Partner);
        if (userInfo is null )
        {
            serviceResponse.Message = "Chưa đăng nhập";
            serviceResponse.Success = false;
            return serviceResponse;
        }
        if ( partnerInfo is null)
        {
            serviceResponse.Message = "Không tìm thấy đối tác";
            serviceResponse.Success = false;
            return serviceResponse;
        }
        if (addInventoryDTO.InventoryDetail.Count == 0)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Không thể nhập kho không có sản phẩm";
            return serviceResponse;
        }

        try
        {
            var newImport = _mapper.Map<Inventory>(addInventoryDTO);
            newImport.User = userInfo;
            newImport.PartnerID = partnerInfo;
            newImport.CreatedAt = DateTime.Now;
            _dataContext.Add(newImport);
            foreach (var item in addInventoryDTO.InventoryDetail)
            {
                var product = await _dataContext.Products.FirstOrDefaultAsync(x => x.ProductID == item.ProductID);
                var importDetail = new InventoryDetail
                {
                    Product = product,
                    InventoryId = newImport,
                    Quantity = item.Quantity
                };
                product.import_count = (product.import_count ?? 0) + item.Quantity;

                _dataContext.inventoryDetails.Add(importDetail);
            }
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetInventoryDTO>(newImport);
        }
        catch (Exception ex)
        {
            serviceResponse.Message = $"Lỗi {ex.Message}";
            serviceResponse.Success = false;
            return serviceResponse;
        }


        return serviceResponse;
    }

    public async Task<ServiceResponse<GetInventoryDTO>> GetByID(int id)
    {
        var serviceResponse = new ServiceResponse<GetInventoryDTO>();
        var inventoryExist = await _dataContext.Inventory.Include(x => x.User).Include(x=>x.PartnerID).FirstOrDefaultAsync(x => x.InventoryID == id);
        if (inventoryExist is null)
        {
            serviceResponse.Message = $"Không tìm thấy phiếu có id là {id}";
            serviceResponse.Success = false;
            return serviceResponse;
        }

        var product = await _dataContext.inventoryDetails.Include(x => x.Product).Where(x => x.InventoryId == inventoryExist).ToListAsync();
        var result = _mapper.Map<GetInventoryDTO>(inventoryExist);
        result.Partner = inventoryExist?.PartnerID?.DisplayName ?? "";
        result.CreatedAt = inventoryExist.CreatedAt.ToString("dd/MM/yyyy");
        // result.InventoryDetail = _mapper.Map<List<InventoryDetailDTO>>(product.Select(x => x.Product));
        var listProductInventory = new List<InventoryDetailDTO>();
        foreach (var item in product)
        {
            var productImage =await _dataContext.Images.Where(x => x.Product == item.Product).Where(x => x.ImagesType == "Product").ToListAsync();
            var newDetail = new InventoryDetailDTO
            {
                ProductID=item.Product.ProductID,
                ProductName=item.Product.ProductName,
                Quantity=item.Quantity,
                Images=productImage.Select(x=>x.ImagesUrl).ToList()
                
            };
            listProductInventory.Add(newDetail);
        }
        result.InventoryDetail = listProductInventory;
        serviceResponse.Data = result;
        serviceResponse.Success = true;

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetAllInventoryDTO>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<GetAllInventoryDTO>>();
        var listinventory = await _dataContext.Inventory.Include(x => x.User).Include(x=>x.PartnerID).ToListAsync();
        var result = listinventory.Select(x => new GetAllInventoryDTO
        {
            UserName = x.User.DisplayName,
            InventoryID = x.InventoryID,
            Partner = x?.PartnerID?.DisplayName  ?? "",
            Description = x.Description,
            Quantity=x.Quantity,
            CreatedAt=x.CreatedAt.ToString("dd/MM/yyyy"),
            Price = x.Price,
            Discount = x.Discount,
            Total = x.Total
        }).ToList();
        serviceResponse.Data = result;
        serviceResponse.Success = true;
        return serviceResponse;
    }
}