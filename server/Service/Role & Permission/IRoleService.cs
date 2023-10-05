using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO.StatusActive;
using server.Models;


namespace server.Service{
    public interface IRoleService
    {
        Task<ServiceResponse<RoleDTO>> GetRoleById(int id);
        Task<ServiceResponse<List<RoleDTO>>> GetAllRole();
        Task<ServiceResponse<List<RoleDTO>>> CreateNewRole(RoleDTO roleDTO);
        Task<ServiceResponse<RoleDTO>> UpdateRole(RoleDTO updateRoleDTO);
        Task<ServiceResponse<List<RoleDTO>>> DeleteRole(int id);
    }
}