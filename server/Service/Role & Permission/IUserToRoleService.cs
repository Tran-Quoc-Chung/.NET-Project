using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO.StatusActive;
using server.Models;


namespace server.Service{
    public interface IUserToRoleService
    {
        Task<ServiceResponse<UserToRoleDetailDTO>> GetRoleByUserId(int id);
        Task<ServiceResponse<List<UserToRoleDetailDTO>>> GetAllUserToRole();
        Task<ServiceResponse<List<UserToRoleDTO>>> CreateNewUserToRole(UserToRoleDTO UserToRoleDTO);
        Task<ServiceResponse<UserToRoleDTO>> UpdateUserToRole(UserToRoleDTO updateUserToRoleDTO);
        Task<ServiceResponse<List<UserToRoleDTO>>> DeleteUserToRole(int id);
    }
}