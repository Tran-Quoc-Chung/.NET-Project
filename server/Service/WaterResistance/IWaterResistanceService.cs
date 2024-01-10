using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO;
using server.DTO.StrapMaterial;
using server.Models;


namespace server.Service{
    public interface IWaterResistanceService
    {
        Task<ServiceResponse<WaterResistanceDTO>> GetById(int id);
        Task<ServiceResponse<List<WaterResistanceDTO>>> GetAll();
        Task<ServiceResponse<List<WaterResistanceDTO>>> Create(WaterResistanceDTO waterResistanceDTO);
        Task<ServiceResponse<WaterResistanceDTO>> Update(WaterResistanceDTO update);
        Task<ServiceResponse<List<WaterResistanceDTO>>> Delete(int id);
    }
}