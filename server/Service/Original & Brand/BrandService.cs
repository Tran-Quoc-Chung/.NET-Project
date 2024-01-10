using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO;
using server.middlewares;

// using server.DTO.Brand;
using server.Models;

namespace server.Service;

public class BrandService : IBrandService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly AuthJwtToken _authJwtToken;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public BrandService(IMapper mapper, DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _authJwtToken = authJwtToken;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<ServiceResponse<BrandDTO>> GetBrandById(int id)
    {

        var serviceResponse = new ServiceResponse<BrandDTO>();
        var dbBrand = await _dataContext.Brands.Include(x=>x.CreatedBy).FirstOrDefaultAsync(x => x.BrandID == id);
        var result = new BrandDTO
        {
            BrandID = dbBrand.BrandID,
            BrandName = dbBrand.BrandName,
            Description = dbBrand?.Description ?? "",
            Origin = dbBrand.Original,
            CreatedAt = dbBrand.CreatedAt.ToString("dd/MM/yyyy"),
            CreatedBy = dbBrand.CreatedBy.DisplayName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<BrandDTO>>> GetAllBrand()
    {
        var serviceResponse = new ServiceResponse<List<BrandDTO>>();
        var dbBrand = await _dataContext.Brands.Include(x=>x.CreatedBy).ToListAsync();
        var result = dbBrand.Select(x => new BrandDTO
        {
            BrandID = x.BrandID,
            BrandName = x.BrandName,
            Origin = x.Original,
            Description = x?.Description ?? "",
            CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy"),
            CreatedBy = x.CreatedBy.DisplayName
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<BrandDTO>>> CreateNewBrand(BrandDTO addBrandDTO)
    {
        var serviceResponse = new ServiceResponse<List<BrandDTO>>();
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
            var Brand = new Brand
            {
                BrandName = addBrandDTO.BrandName,
                Original = addBrandDTO.Origin,
                Description = addBrandDTO.Description,
                CreatedAt = DateTime.Now,
                CreatedBy = userInfo
            };

            _dataContext.Brands.Add(Brand);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Success = true;
            serviceResponse.Message = "Thêm mới thông số thành công";
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Thêm mới thông số thất bại";
        }

        //      serviceResponse.Data = await _dataContext.Brands.Select(x => _mapper.Map<GetBrandDTO>(x)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<BrandDTO>> UpdateBrand(BrandDTO updateBrandDTO)
    {
        var serviceResponse = new ServiceResponse<BrandDTO>();
        try
        {
            var Brand = await _dataContext.Brands.FirstOrDefaultAsync(c => c.BrandID == updateBrandDTO.BrandID);
            if (Brand is null)
                throw new Exception("Update status active false");

            Brand.BrandName = updateBrandDTO.BrandName;
            Brand.Description = updateBrandDTO.Description;
            Brand.Original = updateBrandDTO.Origin;

            await _dataContext.SaveChangesAsync();
            serviceResponse.Message = "Cập nhật thông số thành công";
            serviceResponse.Success = true;
        }
        catch
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<BrandDTO>>> DeleteBrand(int id)
    {
        var serviceResponse = new ServiceResponse<List<BrandDTO>>();
        try
        {
            var Brand = await _dataContext.Brands.FirstOrDefaultAsync(c => c.BrandID == id);
            if (Brand is null)
                throw new Exception("ID status active not found");
            _dataContext.Brands.Remove(Brand);
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