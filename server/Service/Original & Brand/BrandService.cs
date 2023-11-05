using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO;
// using server.DTO.Brand;
using server.Models;

namespace server.Service;

public class BrandService : IBrandService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public BrandService(IMapper mapper, DataContext dataContext)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<GetBrandDTO>> GetBrandById(int id)
    {
        
        var serviceResponse = new ServiceResponse<GetBrandDTO>();
        var dbBrand = await _dataContext.Brands.FirstOrDefaultAsync(x => x.BrandID == id);
        var result = new GetBrandDTO
        {
            BrandID = dbBrand.BrandID,
            BrandName = dbBrand.BrandName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetBrandDTO>>> GetAllBrand()
    {
        var serviceResponse = new ServiceResponse<List<GetBrandDTO>>();
        var dbBrand = await _dataContext.Brands.ToListAsync();
        var result = dbBrand.Select(x => new GetBrandDTO
        {
            BrandID = x.BrandID,
            BrandName = x.BrandName
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetBrandDTO>>> CreateNewBrand(AddBrandDTO addBrandDTO)
    {
        var serviceResponse = new ServiceResponse<List<GetBrandDTO>>();
        var Brand = _mapper.Map<Brand>(addBrandDTO);
        _dataContext.Brands.Add(Brand);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await _dataContext.Brands.Select(x => _mapper.Map<GetBrandDTO>(x)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetBrandDTO>> UpdateBrand(UpdateBrandDTO updateBrandDTO)
    {
        var serviceResponse = new ServiceResponse<GetBrandDTO>();
        try{
              var Brand = await _dataContext.Brands.FirstOrDefaultAsync(c => c.BrandID == updateBrandDTO.BrandID);
            if (Brand is null)
                throw new Exception("Update status active false");
        
        Brand.BrandName = updateBrandDTO.BrandName;
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetBrandDTO>(Brand);
        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
      
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetBrandDTO>>> DeleteBrand(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetBrandDTO>>();
        try{
            var Brand = await _dataContext.Brands.FirstOrDefaultAsync(c => c.BrandID == id);
            if(Brand is null)
                throw new Exception("ID status active not found");
            _dataContext.Brands.Remove(Brand);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.Brands.Select(x => _mapper.Map<GetBrandDTO>(x)).ToListAsync();

        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }
}