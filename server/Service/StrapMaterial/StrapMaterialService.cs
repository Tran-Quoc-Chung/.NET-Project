using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO;
using server.DTO.StrapMaterial;
using server.middlewares;
using server.Models;

namespace server.Service;

public class StrapMaterialService : IStrapMaterialService
{
    private readonly DataContext _dataContext;
    private readonly AuthJwtToken _authJwtToken;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public StrapMaterialService( DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor)
    {
        _dataContext = dataContext;
        _authJwtToken = authJwtToken;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<ServiceResponse<GetStrapMaterialDTO>> GetById(int id)
    {

        var serviceResponse = new ServiceResponse<GetStrapMaterialDTO>();
        var dbStrapMaterial = await _dataContext.StrapMaterials.Include(x=>x.CreatedBy).FirstOrDefaultAsync(x => x.StrapMaterialID == id);
        var result = new GetStrapMaterialDTO
        {
            StrapMaterialID = dbStrapMaterial.StrapMaterialID,
            StrapMaterialName = dbStrapMaterial.StrapMaterialName,
            Description = dbStrapMaterial?.Description ?? "",
            CreatedAt = dbStrapMaterial.CreatedAt.ToString("dd/MM/yyyy"),
            CreatedBy = dbStrapMaterial.CreatedBy.DisplayName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetStrapMaterialDTO>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<GetStrapMaterialDTO>>();
        var dbStrapMaterial = await _dataContext.StrapMaterials.Include(x=>x.CreatedBy).ToListAsync();
        try
        {
            var result = dbStrapMaterial.Select(x => new GetStrapMaterialDTO
        {
            StrapMaterialID = x.StrapMaterialID,
            StrapMaterialName = x.StrapMaterialName,
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

    public async Task<ServiceResponse<List<GetStrapMaterialDTO>>> Create(GetStrapMaterialDTO getStrapMaterialDTO)
    {
        var serviceResponse = new ServiceResponse<List<GetStrapMaterialDTO>>();
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
        var StrapMaterial = new StrapMaterial {
            StrapMaterialName = getStrapMaterialDTO.StrapMaterialName,
            Description = getStrapMaterialDTO?.Description ?? "",
            CreatedAt=DateTime.Now,
            CreatedBy=userInfo
        };

        _dataContext.StrapMaterials.Add(StrapMaterial);
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

    public async Task<ServiceResponse<GetStrapMaterialDTO>> Update(GetStrapMaterialDTO getStrapMaterialDTO)
    {
        var serviceResponse = new ServiceResponse<GetStrapMaterialDTO>();
        try
        {
            var StrapMaterial = await _dataContext.StrapMaterials.FirstOrDefaultAsync(c => c.StrapMaterialID == getStrapMaterialDTO.StrapMaterialID);
            if(StrapMaterial is null)
                throw new Exception("Không tìm thấy thông số có ID là "+getStrapMaterialDTO.StrapMaterialID );

            StrapMaterial.StrapMaterialName = getStrapMaterialDTO.StrapMaterialName;
            StrapMaterial.Description = getStrapMaterialDTO.Description;
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

    public async Task<ServiceResponse<List<GetStrapMaterialDTO>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetStrapMaterialDTO>>();
        try
        {
            var StrapMaterial = await _dataContext.StrapMaterials.FirstOrDefaultAsync(c => c.StrapMaterialID == id);
            if (StrapMaterial is null)
                throw new Exception("Không tìm thấy thông số có ID là "+ id);
            _dataContext.StrapMaterials.Remove(StrapMaterial);
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