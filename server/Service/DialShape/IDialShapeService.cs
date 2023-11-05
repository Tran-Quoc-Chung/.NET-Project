using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO.DialShape;
using server.Models;


namespace server.Service{
    public interface IDialShapeService
    {
        Task<ServiceResponse<GetDialShapeDTO>> GetDialShapeById(int id);
        Task<ServiceResponse<List<GetDialShapeDTO>>> GetAllDialShape();
        Task<ServiceResponse<List<GetDialShapeDTO>>> CreateNewDialShape(AddDialShapeDTO addDialShapeDTO);
        Task<ServiceResponse<GetDialShapeDTO>> UpdateDialShape(UpdateDialShapeDTO updateDialShapeDTO);
        Task<ServiceResponse<List<GetDialShapeDTO>>> DeleteDialShape(int id);
    }
}