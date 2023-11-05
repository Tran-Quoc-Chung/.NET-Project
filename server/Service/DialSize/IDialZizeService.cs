using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO;
using server.DTO.DialSize;
using server.Models;


namespace server.Service{
    public interface IDialSizeService
    {
        Task<ServiceResponse<GetDialSizeDTO>> GetDialSizeById(int id);
        Task<ServiceResponse<List<GetDialSizeDTO>>> GetAllDialSize();
        Task<ServiceResponse<List<GetDialSizeDTO>>> CreateNewDialSize(AddDialSizeDTO addDialSizeDTO);
        Task<ServiceResponse<GetDialSizeDTO>> UpdateDialSize(UpdateDialSizeDTO updateDialSizeDTO);
        Task<ServiceResponse<List<GetDialSizeDTO>>> DeleteDialSize(int id);
    }
}