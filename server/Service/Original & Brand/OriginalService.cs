using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO;
using server.Models;

namespace server.Service;

public class OriginalService : IOriginalService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public OriginalService(IMapper mapper, DataContext dataContext)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<GetOriginalDTO>> GetOriginalById(int id)
    {
        
        var serviceResponse = new ServiceResponse<GetOriginalDTO>();
        var dbOriginal = await _dataContext.Originals.FirstOrDefaultAsync(x => x.OriginalID == id);
        var result = new GetOriginalDTO
        {
            OriginalID = dbOriginal.OriginalID,
            OriginalName = dbOriginal.OriginalName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetOriginalDTO>>> GetAllOriginal()
    {
        var serviceResponse = new ServiceResponse<List<GetOriginalDTO>>();
        var dbOriginal = await _dataContext.Originals.ToListAsync();
        var result = dbOriginal.Select(x => new GetOriginalDTO
        {
            OriginalID = x.OriginalID,
            OriginalName = x.OriginalName
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetOriginalDTO>>> CreateNewOriginal(AddOriginalDTO addOriginalDTO)
    {
        var serviceResponse = new ServiceResponse<List<GetOriginalDTO>>();
        var Original = _mapper.Map<Original>(addOriginalDTO);
        _dataContext.Originals.Add(Original);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await _dataContext.Originals.Select(x => _mapper.Map<GetOriginalDTO>(x)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetOriginalDTO>> UpdateOriginal(UpdateOriginalDTO updateOriginalDTO)
    {
        var serviceResponse = new ServiceResponse<GetOriginalDTO>();
        try{
              var Original = await _dataContext.Originals.FirstOrDefaultAsync(c => c.OriginalID == updateOriginalDTO.OriginalID);
            if (Original is null)
                throw new Exception("Update status active false");
        
        Original.OriginalName = updateOriginalDTO.OriginalName;
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetOriginalDTO>(Original);
        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
      
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetOriginalDTO>>> DeleteOriginal(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetOriginalDTO>>();
        try{
            var Original = await _dataContext.Originals.FirstOrDefaultAsync(c => c.OriginalID == id);
            if(Original is null)
                throw new Exception("ID status active not found");
            _dataContext.Originals.Remove(Original);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.Originals.Select(x => _mapper.Map<GetOriginalDTO>(x)).ToListAsync();

        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }
}