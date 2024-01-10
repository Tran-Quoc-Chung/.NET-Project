using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO;
using server.DTO.StrapMaterial;
using server.Models;


namespace server.Service{
    public interface IPartnerService
    {
        Task<ServiceResponse<PartnerDTO>> GetById(int id);
        Task<ServiceResponse<List<PartnerDTO>>> GetAll();
        Task<ServiceResponse<List<PartnerDTO>>> Create(PartnerDTO PartnerDTO);
        Task<ServiceResponse<PartnerDTO>> Update(PartnerDTO update);
        Task<ServiceResponse<List<PartnerDTO>>> Delete(int id);
    }
}