using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO.DialShape;
using server.Models;

namespace server.Service;

public class DialShapeService : IDialShapeService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public DialShapeService(IMapper mapper, DataContext dataContext)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<GetDialShapeDTO>> GetDialShapeById(int id)
    {
        
        var serviceResponse = new ServiceResponse<GetDialShapeDTO>();
        var dbDialShape = await _dataContext.DialShapes.FirstOrDefaultAsync(x => x.DialShapeID == id);
        var result = new GetDialShapeDTO
        {
            DialShapeID = dbDialShape.DialShapeID,
            DialShapeName = dbDialShape.DialShapeName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetDialShapeDTO>>> GetAllDialShape()
    {
        var serviceResponse = new ServiceResponse<List<GetDialShapeDTO>>();
        var dbDialShape = await _dataContext.DialShapes.ToListAsync();
        var result = dbDialShape.Select(x => new GetDialShapeDTO
        {
            DialShapeID = x.DialShapeID,
            DialShapeName = x.DialShapeName
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetDialShapeDTO>>> CreateNewDialShape(AddDialShapeDTO addDialShapeDTO)
    {
        var serviceResponse = new ServiceResponse<List<GetDialShapeDTO>>();
        var DialShape = _mapper.Map<DialShape>(addDialShapeDTO);
        _dataContext.DialShapes.Add(DialShape);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await _dataContext.DialShapes.Select(x => _mapper.Map<GetDialShapeDTO>(x)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetDialShapeDTO>> UpdateDialShape(UpdateDialShapeDTO updateDialShapeDTO)
    {
        var serviceResponse = new ServiceResponse<GetDialShapeDTO>();
        try{
              var DialShape = await _dataContext.DialShapes.FirstOrDefaultAsync(c => c.DialShapeID == updateDialShapeDTO.DialShapeID);
            if (DialShape is null)
                throw new Exception("Update DialShape false");
        
        DialShape.DialShapeName = updateDialShapeDTO.DialShapeName;
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetDialShapeDTO>(DialShape);
        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
      
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetDialShapeDTO>>> DeleteDialShape(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetDialShapeDTO>>();
        try{
            var DialShape = await _dataContext.DialShapes.FirstOrDefaultAsync(c => c.DialShapeID == id);
            if(DialShape is null)
                throw new Exception("ID dialShape not found");
            _dataContext.DialShapes.Remove(DialShape);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.DialShapes.Select(x => _mapper.Map<GetDialShapeDTO>(x)).ToListAsync();

        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }
}