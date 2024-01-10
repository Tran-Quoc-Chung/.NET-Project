using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTO;
using server.middlewares;
using server.Models;

namespace server.Service;

public class DialShapeService : IDialShapeService
{
    private readonly DataContext _dataContext;
    private readonly AuthJwtToken _authJwtToken;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public DialShapeService( DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor)
    {
        _dataContext = dataContext;
        _authJwtToken = authJwtToken;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<ServiceResponse<DialShapeDTO>> GetById(int id)
    {

        var serviceResponse = new ServiceResponse<DialShapeDTO>();
        var dialShape = await _dataContext.DialShapes.Include(x=>x.CreatedBy).FirstOrDefaultAsync(x => x.DialShapeID == id);
        var result = new DialShapeDTO
        {
            DialShapeID=dialShape.DialShapeID,
            DialShapeName=dialShape.DialShapeName,
            Description = dialShape?.Description ?? "",
            CreatedAt = dialShape.CreatedAt.ToString("dd/MM/yyyy"),
            CreatedBy = dialShape.CreatedBy.DisplayName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<DialShapeDTO>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<DialShapeDTO>>();
        var dialShape = await _dataContext.DialShapes.Include(x=>x.CreatedBy).ToListAsync();
        try
        {
            var result = dialShape.Select(x => new DialShapeDTO
        {
            DialShapeID = x.DialShapeID,
            DialShapeName = x.DialShapeName,
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

    public async Task<ServiceResponse<List<DialShapeDTO>>> Create(DialShapeDTO dialShapeDTO)
    {
        var serviceResponse = new ServiceResponse<List<DialShapeDTO>>();
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
        var dialShape = new DialShape {
            DialShapeName = dialShapeDTO.DialShapeName,
            Description = dialShapeDTO?.Description ?? "",
            CreatedAt=DateTime.Now,
            CreatedBy=userInfo
        };

        _dataContext.DialShapes.Add(dialShape);
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

    public async Task<ServiceResponse<DialShapeDTO>> Update(DialShapeDTO DialShapeDTO)
    {
        var serviceResponse = new ServiceResponse<DialShapeDTO>();
        try
        {
            var dialShape = await _dataContext.DialShapes.FirstOrDefaultAsync(c => c.DialShapeID == DialShapeDTO.DialShapeID);
            if(dialShape is null)
                throw new Exception("Không tìm thấy thông số có ID là "+dialShape.DialShapeID );

            dialShape.DialShapeName = DialShapeDTO.DialShapeName;
            dialShape.Description = DialShapeDTO.Description;
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

    public async Task<ServiceResponse<List<DialShapeDTO>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<DialShapeDTO>>();
        try
        {
            var dialShape = await _dataContext.DialShapes.FirstOrDefaultAsync(c => c.DialShapeID == id);
            if (dialShape is null)
                throw new Exception("Không tìm thấy thông số có ID là "+ id);
            _dataContext.DialShapes.Remove(dialShape);
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