using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO.StatusActive;
using server.Models;


namespace server.Service{
    public interface IPermissionService
    {
        Task<ServiceResponse<PermissionDTO>> GetPermissionById(int id);
        Task<ServiceResponse<List<PermissionDTO>>> GetAllPermission();
        Task<ServiceResponse<List<PermissionDTO>>> CreateNewPermission(PermissionDTO PermissionDTO);
        Task<ServiceResponse<PermissionDTO>> UpdatePermission(PermissionDTO updatePermissionDTO);
        Task<ServiceResponse<List<PermissionDTO>>> DeletePermission(int id);
    }
}