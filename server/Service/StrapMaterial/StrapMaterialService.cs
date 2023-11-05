using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO;
using server.DTO.StrapMaterial;
using server.Models;

namespace server.Service;

public class StrapMaterialService : IStrapMaterialService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public StrapMaterialService(IMapper mapper, DataContext dataContext)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<GetStrapMaterialDTO>> GetStrapMaterialById(int id)
    {
        
        var serviceResponse = new ServiceResponse<GetStrapMaterialDTO>();
        var dbStrapMaterial = await _dataContext.StrapMaterials.FirstOrDefaultAsync(x => x.StrapMaterialID == id);
        var result = new GetStrapMaterialDTO
        {
            StrapMaterialID = dbStrapMaterial.StrapMaterialID,
            StrapMaterialName = dbStrapMaterial.StrapMaterialName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetStrapMaterialDTO>>> GetAllStrapMaterial()
    {
        var serviceResponse = new ServiceResponse<List<GetStrapMaterialDTO>>();
        var dbStrapMaterial = await _dataContext.StrapMaterials.ToListAsync();
        var result = dbStrapMaterial.Select(x => new GetStrapMaterialDTO
        {
            StrapMaterialID = x.StrapMaterialID,
            StrapMaterialName = x.StrapMaterialName
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetStrapMaterialDTO>>> CreateNewStrapMaterial(AddStrapMaterialDTO addStrapMaterialDTO)
    {
        var serviceResponse = new ServiceResponse<List<GetStrapMaterialDTO>>();
        var StrapMaterial = _mapper.Map<StrapMaterial>(addStrapMaterialDTO);
        _dataContext.StrapMaterials.Add(StrapMaterial);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await _dataContext.StrapMaterials.Select(x => _mapper.Map<GetStrapMaterialDTO>(x)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetStrapMaterialDTO>> UpdateStrapMaterial(UpdateStrapMaterialDTO updateStrapMaterialDTO)
    {
        var serviceResponse = new ServiceResponse<GetStrapMaterialDTO>();
        try{
              var StrapMaterial = await _dataContext.StrapMaterials.FirstOrDefaultAsync(c => c.StrapMaterialID == updateStrapMaterialDTO.StrapMaterialID);
            if (StrapMaterial is null)
                throw new Exception("Update strapMaterial false");
        
        StrapMaterial.StrapMaterialName = updateStrapMaterialDTO.StrapMaterialName;
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetStrapMaterialDTO>(StrapMaterial);
        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
      
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetStrapMaterialDTO>>> DeleteStrapMaterial(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetStrapMaterialDTO>>();
        try{
            var StrapMaterial = await _dataContext.StrapMaterials.FirstOrDefaultAsync(c => c.StrapMaterialID == id);
            if(StrapMaterial is null)
                throw new Exception("ID strapMaterial not found");
            _dataContext.StrapMaterials.Remove(StrapMaterial);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.StrapMaterials.Select(x => _mapper.Map<GetStrapMaterialDTO>(x)).ToListAsync();

        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }
}