using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO;
using server.DTO.StrapMaterial;
using server.Models;


namespace server.Service{
    public interface IStrapMaterialService
    {
        Task<ServiceResponse<GetStrapMaterialDTO>> GetById(int id);
        Task<ServiceResponse<List<GetStrapMaterialDTO>>> GetAll();
        Task<ServiceResponse<List<GetStrapMaterialDTO>>> Create(GetStrapMaterialDTO getStrapMaterialDTO);
        Task<ServiceResponse<GetStrapMaterialDTO>> Update(GetStrapMaterialDTO updateStrapMaterialDTO);
        Task<ServiceResponse<List<GetStrapMaterialDTO>>> Delete(int id);
    }
}