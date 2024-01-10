using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO.Tag;
using server.Models;

namespace server.Service;

public class TagService : ITagService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public TagService(IMapper mapper, DataContext dataContext)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<GetTagDTO>> GetTagById(int id)
    {
        
        var serviceResponse = new ServiceResponse<GetTagDTO>();
        var dbTag = await _dataContext.Tags.FirstOrDefaultAsync(x => x.TagID == id);
        var result = new GetTagDTO
        {
            TagID = dbTag.TagID,
            TagName = dbTag.TagName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetTagDTO>>> GetAllTag()
    {
        var serviceResponse = new ServiceResponse<List<GetTagDTO>>();
        var dbTag = await _dataContext.Tags.ToListAsync();
        var result = dbTag.Select(x => new GetTagDTO
        {
            TagID = x.TagID,
            TagName = x.TagName
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetTagDTO>>> CreateNewTag(AddTagDTO addTagDTO)
    {
        var serviceResponse = new ServiceResponse<List<GetTagDTO>>();
        var Tag = _mapper.Map<Tag>(addTagDTO);
        _dataContext.Tags.Add(Tag);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await _dataContext.Tags.Select(x => _mapper.Map<GetTagDTO>(x)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetTagDTO>> UpdateTag(UpdateTagDTO updateTagDTO)
    {
        var serviceResponse = new ServiceResponse<GetTagDTO>();
        try{
              var Tag = await _dataContext.Tags.FirstOrDefaultAsync(c => c.TagID == updateTagDTO.TagID);
            if (Tag is null)
                throw new Exception("Update tag false");
        
        Tag.TagName = updateTagDTO.TagName;
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetTagDTO>(Tag);
        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
      
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetTagDTO>>> DeleteTag(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetTagDTO>>();
        try{
            var Tag = await _dataContext.Tags.FirstOrDefaultAsync(c => c.TagID == id);
            if(Tag is null)
                throw new Exception("ID tag not found");
            _dataContext.Tags.Remove(Tag);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.Tags.Select(x => _mapper.Map<GetTagDTO>(x)).ToListAsync();

        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }
}