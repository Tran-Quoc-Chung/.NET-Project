using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO.DialSize;
using server.Models;

namespace server.Service;

public class DialSizeService : IDialSizeService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public DialSizeService(IMapper mapper, DataContext dataContext)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<GetDialSizeDTO>> GetDialSizeById(int id)
    {
        
        var serviceResponse = new ServiceResponse<GetDialSizeDTO>();
        var dbDialSize = await _dataContext.DialSizes.FirstOrDefaultAsync(x => x.DialSizeID == id);
        var result = new GetDialSizeDTO
        {
            DialSizeID = dbDialSize.DialSizeID,
            DialSizeName = dbDialSize.DialSizeName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetDialSizeDTO>>> GetAllDialSize()
    {
        var serviceResponse = new ServiceResponse<List<GetDialSizeDTO>>();
        var dbDialSize = await _dataContext.DialSizes.ToListAsync();
        var result = dbDialSize.Select(x => new GetDialSizeDTO
        {
            DialSizeID = x.DialSizeID,
            DialSizeName = x.DialSizeName
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetDialSizeDTO>>> CreateNewDialSize(AddDialSizeDTO addDialSizeDTO)
    {
        var serviceResponse = new ServiceResponse<List<GetDialSizeDTO>>();
        var DialSize = _mapper.Map<DialSize>(addDialSizeDTO);
        _dataContext.DialSizes.Add(DialSize);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await _dataContext.DialSizes.Select(x => _mapper.Map<GetDialSizeDTO>(x)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetDialSizeDTO>> UpdateDialSize(UpdateDialSizeDTO updateDialSizeDTO)
    {
        var serviceResponse = new ServiceResponse<GetDialSizeDTO>();
        try{
              var DialSize = await _dataContext.DialSizes.FirstOrDefaultAsync(c => c.DialSizeID == updateDialSizeDTO.DialSizeID);
            if (DialSize is null)
                throw new Exception("Update dialSize false");
        
        DialSize.DialSizeName = updateDialSizeDTO.DialSizeName;
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetDialSizeDTO>(DialSize);
        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
      
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetDialSizeDTO>>> DeleteDialSize(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetDialSizeDTO>>();
        try{
            var DialSize = await _dataContext.DialSizes.FirstOrDefaultAsync(c => c.DialSizeID == id);
            if(DialSize is null)
                throw new Exception("ID dialSize not found");
            _dataContext.DialSizes.Remove(DialSize);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.DialSizes.Select(x => _mapper.Map<GetDialSizeDTO>(x)).ToListAsync();

        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }
}