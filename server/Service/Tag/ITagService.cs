using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO.Tag;
using server.Models;


namespace server.Service{
    public interface ITagService
    {
        Task<ServiceResponse<GetTagDTO>> GetTagById(int id);
        Task<ServiceResponse<List<GetTagDTO>>> GetAllTag();
        Task<ServiceResponse<List<GetTagDTO>>> CreateNewTag(AddTagDTO addTagDTO);
        Task<ServiceResponse<GetTagDTO>> UpdateTag(UpdateTagDTO updateTagDTO);
        Task<ServiceResponse<List<GetTagDTO>>> DeleteTag(int id);
    }
}