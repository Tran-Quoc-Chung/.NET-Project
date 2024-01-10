using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTO;
using server.middlewares;
using server.Models;

namespace server.Service;

public class WaterResistanceService : IWaterResistanceService
{
    private readonly DataContext _dataContext;
    private readonly AuthJwtToken _authJwtToken;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public WaterResistanceService( DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor)
    {
        _dataContext = dataContext;
        _authJwtToken = authJwtToken;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<ServiceResponse<WaterResistanceDTO>> GetById(int id)
    {

        var serviceResponse = new ServiceResponse<WaterResistanceDTO>();
        var dbWaterResistance = await _dataContext.WaterResistances.Include(x=>x.CreatedBy).FirstOrDefaultAsync(x => x.WaterResistanceID == id);
        var result = new WaterResistanceDTO
        {
            WaterResistanceID = dbWaterResistance.WaterResistanceID,
            WaterResistanceName = dbWaterResistance.WaterResistanceName,
            Description = dbWaterResistance?.Description ?? "",
            CreatedAt = dbWaterResistance.CreatedAt.ToString("dd/MM/yyyy"),
            CreatedBy = dbWaterResistance.CreatedBy.DisplayName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<WaterResistanceDTO>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<WaterResistanceDTO>>();
        var dbWaterResistance = await _dataContext.WaterResistances.Include(x=>x.CreatedBy).ToListAsync();
        try
        {
            var result = dbWaterResistance.Select(x => new WaterResistanceDTO
        {
            WaterResistanceID = x.WaterResistanceID,
            WaterResistanceName = x.WaterResistanceName,
             Description = x?.Description ?? "",
            CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
             CreatedBy = x.CreatedBy.DisplayName ?? ""
        }).ToList();
        serviceResponse.Data = result;
            serviceResponse.Success = true;
            
        }
        catch (System.Exception)
        {
            serviceResponse.Success = false;
            throw;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<WaterResistanceDTO>>> Create(WaterResistanceDTO waterResistanceDTO)
    {
        var serviceResponse = new ServiceResponse<List<WaterResistanceDTO>>();
        var token = _httpContextAccessor.HttpContext.Request.Cookies["user"];
        try
        {
            var userID = _authJwtToken.ValidateToken(token);
        var userInfo = await _dataContext.Users.SingleOrDefaultAsync(x => x.UserID == userID.UserID);
        if (userInfo == null)
        {
            serviceResponse.Message = "Người dùng chưa đăng nhập";
            serviceResponse.Success = false;
            return serviceResponse;
        }
        var waterResistance = new WaterResistance {
            WaterResistanceName = waterResistanceDTO.WaterResistanceName,
            Description = waterResistanceDTO?.Description ?? "",
            CreatedAt=DateTime.Now,
            CreatedBy=userInfo
        };

        _dataContext.WaterResistances.Add(waterResistance);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Success = true;
            serviceResponse.Message = "Thêm mới thông số thành công";
        }
        catch (System.Exception)
        {
             serviceResponse.Success = false;
            serviceResponse.Message = "Thêm mới thông số thất bại";
            throw;
        }
       
        return serviceResponse;
    }

    public async Task<ServiceResponse<WaterResistanceDTO>> Update(WaterResistanceDTO waterResistanceDTO)
    {
        var serviceResponse = new ServiceResponse<WaterResistanceDTO>();
        try
        {
            var waterResistance = await _dataContext.WaterResistances.FirstOrDefaultAsync(c => c.WaterResistanceID == waterResistanceDTO.WaterResistanceID);
            if(waterResistance is null)
                throw new Exception("Không tìm thấy thông số có ID là "+waterResistanceDTO.WaterResistanceID );

            waterResistance.WaterResistanceName = waterResistanceDTO.WaterResistanceName;
            waterResistance.Description = waterResistanceDTO.Description;
            await _dataContext.SaveChangesAsync();
        serviceResponse.Success = true;
            serviceResponse.Message = "Cập nhật thông số thành công";
        }
        catch
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Cập nhật thông số thất bại";
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<WaterResistanceDTO>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<WaterResistanceDTO>>();
        try
        {
            var waterResistance = await _dataContext.WaterResistances.FirstOrDefaultAsync(c => c.WaterResistanceID == id);
            if (waterResistance is null)
                throw new Exception("Không tìm thấy thông số có ID là "+ id);
            _dataContext.WaterResistances.Remove(waterResistance);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Success = true;
            serviceResponse.Message = "Xóa thông số thành công";

        }
        catch
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Xóa thông số thất bại";
        }
        return serviceResponse;
    }
}