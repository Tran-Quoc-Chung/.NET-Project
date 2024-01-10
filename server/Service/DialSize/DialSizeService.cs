using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTO;
using server.DTO.DialSize;
using server.middlewares;
using server.Models;

namespace server.Service;

public class DialSizeService : IDialSizeService
{
    private readonly DataContext _dataContext;
    private readonly AuthJwtToken _authJwtToken;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public DialSizeService(DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor)
    {
        _dataContext = dataContext;
        _authJwtToken = authJwtToken;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<ServiceResponse<DialSizeDTO>> GetById(int id)
    {

        var serviceResponse = new ServiceResponse<DialSizeDTO>();
        var dialSize = await _dataContext.DialSizes.Include(x => x.CreatedBy).FirstOrDefaultAsync(x => x.DialSizeID == id);
        var result = new DialSizeDTO
        {
            DialSizeID = dialSize.DialSizeID,
            DialSizeName = dialSize.DialSizeName,
            Description = dialSize?.Description ?? "",
            CreatedAt = dialSize.CreatedAt.ToString("dd/MM/yyyy"),
            CreatedBy = dialSize.CreatedBy.DisplayName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<DialSizeDTO>>> GetAll()
    {
        var serviceResponse = new ServiceResponse<List<DialSizeDTO>>();
        var dialSize = await _dataContext.DialSizes.Include(x => x.CreatedBy).ToListAsync();
        try
        {
            var result = dialSize.Select(x => new DialSizeDTO
            {
                DialSizeID = x.DialSizeID,
                DialSizeName = x.DialSizeName,
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

    public async Task<ServiceResponse<List<DialSizeDTO>>> Create(DialSizeDTO dialSizeDTO)
    {
        var serviceResponse = new ServiceResponse<List<DialSizeDTO>>();
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
            var dialSize = new DialSize
            {
                DialSizeName = dialSizeDTO.DialSizeName,
                Description = dialSizeDTO?.Description ?? "",
                CreatedAt = DateTime.Now,
                CreatedBy = userInfo
            };

            _dataContext.DialSizes.Add(dialSize);
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

    public async Task<ServiceResponse<DialSizeDTO>> Update(DialSizeDTO DialSizeDTO)
    {
        var serviceResponse = new ServiceResponse<DialSizeDTO>();
        try
        {
            var dialSize = await _dataContext.DialSizes.FirstOrDefaultAsync(c => c.DialSizeID == DialSizeDTO.DialSizeID);
            if (dialSize is null)
                throw new Exception("Không tìm thấy thông số có ID là " + dialSize.DialSizeID);

            dialSize.DialSizeName = DialSizeDTO.DialSizeName;
            dialSize.Description = DialSizeDTO.Description;
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

    public async Task<ServiceResponse<List<DialSizeDTO>>> Delete(int id)
    {
        var serviceResponse = new ServiceResponse<List<DialSizeDTO>>();
        try
        {
            var dialSize = await _dataContext.DialSizes.FirstOrDefaultAsync(c => c.DialSizeID == id);
            if (dialSize is null)
                throw new Exception("Không tìm thấy thông số có ID là " + id);
            _dataContext.DialSizes.Remove(dialSize);
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