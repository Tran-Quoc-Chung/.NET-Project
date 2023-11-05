using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO;
using server.DTO.StrapMaterial;
using server.Models;


namespace server.Service{
    public interface IStrapMaterialService
    {
        Task<ServiceResponse<GetStrapMaterialDTO>> GetStrapMaterialById(int id);
        Task<ServiceResponse<List<GetStrapMaterialDTO>>> GetAllStrapMaterial();
        Task<ServiceResponse<List<GetStrapMaterialDTO>>> CreateNewStrapMaterial(AddStrapMaterialDTO addStrapMaterialDTO);
        Task<ServiceResponse<GetStrapMaterialDTO>> UpdateStrapMaterial(UpdateStrapMaterialDTO updateStrapMaterialDTO);
        Task<ServiceResponse<List<GetStrapMaterialDTO>>> DeleteStrapMaterial(int id);
    }
}