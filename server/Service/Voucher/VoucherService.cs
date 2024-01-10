using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO.Voucher;
using server.middlewares;
using server.Models;

namespace server.Service;

public class VoucherService : IVoucherService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly AuthJwtToken _authJwtToken;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public VoucherService(IMapper mapper, DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _authJwtToken = authJwtToken;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<ServiceResponse<GetVoucherDTO>> GetVoucherByCode(string code)
    {

        var serviceResponse = new ServiceResponse<GetVoucherDTO>();
        var dbVoucher = await _dataContext.Vouchers.Include(x => x.CreatedBy).Include(x => x.VoucherStatus).FirstOrDefaultAsync(x => x.VoucherCode == code);
        if (dbVoucher is null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = $"Không tìm thấy voucher có mã là {code}";
            return serviceResponse;
        }
        var result = new GetVoucherDTO
        {
            VoucherCode = dbVoucher.VoucherCode,
            EventName = dbVoucher.EventName,
            Discount = dbVoucher.Discount,
            Quantity = dbVoucher.Quantity,
            QuantityRemain = dbVoucher.QuantityRemain,
            Description = dbVoucher.Description,
            VoucherStatusName = dbVoucher.VoucherStatus.StatusName,
            StartDate = dbVoucher.StartDate.ToString("dd/MM/yyyy"),
            EndDate = dbVoucher.EndDate.ToString("dd/MM/yyyy"),
            CreatedBy = dbVoucher.CreatedBy.DisplayName,
            CreatedAt = dbVoucher.CreatedAt.ToString("dd/MM/yyyy")
        };

        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetVoucherDTO>>> GetAllVoucher()
    {
        var serviceResponse = new ServiceResponse<List<GetVoucherDTO>>();
        var dbVoucher = await _dataContext.Vouchers.ToListAsync();
        var result = dbVoucher.Select(x => new GetVoucherDTO
        {
            VoucherCode = x.VoucherCode,
            EventName = x.EventName,
            Discount = x.Discount,
            Description = x.Description,
            StartDate = x.StartDate.ToString("dd/MM/yyyy"),
            EndDate = x.EndDate.ToString("dd/MM/yyyy"),
            Quantity = x.Quantity
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetVoucherDTO>> Create(AddVoucherDTO addVoucherDTO)
    {
        var serviceResponse = new ServiceResponse<GetVoucherDTO>();
        var voucherExist = await _dataContext.Vouchers.SingleOrDefaultAsync(x => x.VoucherCode == addVoucherDTO.VoucherCode);
        if(voucherExist !=null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Đã tồn tại mã voucher là " + addVoucherDTO.VoucherCode;
            return serviceResponse;
        }
        var Voucher = _mapper.Map<Voucher>(addVoucherDTO);
        var status = await _dataContext.SystemStatus.SingleOrDefaultAsync(x => x.StatusID == addVoucherDTO.Status);
        if (status is null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Dữ liệu không hợp lệ";
            return serviceResponse;
        }
        var token = _httpContextAccessor.HttpContext.Request.Cookies["user"];
        var userID = _authJwtToken.ValidateToken(token);
        var userInfo = await _dataContext.Users.SingleOrDefaultAsync(x => x.UserID == userID.UserID);
        if (userInfo is null || token is null)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Chưa đăng nhập";
            return serviceResponse;
        }
        Voucher.VoucherStatus = status;
        Voucher.QuantityRemain = addVoucherDTO.Quantity;
        Voucher.CreatedBy = userInfo;
        Voucher.CreatedAt = DateTime.Now;
        _dataContext.Vouchers.Add(Voucher);
        await _dataContext.SaveChangesAsync();

        serviceResponse.Data = _mapper.Map<GetVoucherDTO>(Voucher);
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetVoucherDTO>> UpdateVoucher(AddVoucherDTO addVoucherDTO)
    {
        var serviceResponse = new ServiceResponse<GetVoucherDTO>();
        var Voucher = await _dataContext.Vouchers.FirstOrDefaultAsync(c => c.VoucherCode == addVoucherDTO.VoucherCode);
        if (Voucher is null)
            throw new Exception("Cập nhật voucher thất bại");

        Voucher.EventName=addVoucherDTO.EventName;
        Voucher.Discount=addVoucherDTO.Discount;
        Voucher.Quantity=addVoucherDTO.Quantity;
        Voucher.Description=addVoucherDTO.Description;
        Voucher.StartDate=addVoucherDTO.StartDate;
        Voucher.EndDate=addVoucherDTO.EndDate;

        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetVoucherDTO>(Voucher);
        serviceResponse.Success = true;
        serviceResponse.Message = "Cập nhật voucher thành công";
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetVoucherDTO>> DeleteVoucher(string code)
    {
        var serviceResponse = new ServiceResponse<GetVoucherDTO>();
        try
        {
            var Voucher = await _dataContext.Vouchers.FirstOrDefaultAsync(c => c.VoucherCode == code);
            if (Voucher is null)
                throw new Exception("Không tìm thấy voucher");
            _dataContext.Vouchers.Remove(Voucher);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Success = true;
            serviceResponse.Message = "Xóa voucher thành công";
        }
        catch
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }


}