using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO.StatusActive;
using server.Models;


namespace server.Service{
    public interface IRoleToPermissionService
    {
        Task<ServiceResponse<RoleToPermissionDetailDTO>> CreateRoleToPermission(RoleToPermissionDTO roleToPermissionDTO);
        Task<ServiceResponse<RoleToPermissionDetailDTO>> GetAllPermissionByRoleID(int RoldID);
    }
}