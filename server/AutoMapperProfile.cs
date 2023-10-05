using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using server.DTO;
using server.DTO.StatusActive;
using server.Models;


namespace server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<StatusActive, GetStatusActiveDTO>();
            CreateMap<AddStatusActiveDTO, StatusActive>();
            CreateMap<AddUserDTO, User>();
            CreateMap<User, GetUserDTO>();
            CreateMap<StatusActive, GetUserDTO>();
            CreateMap<RoleDTO, Role>();
            CreateMap<Role, RoleDTO>();
            CreateMap<PermissionDTO, Permission>();
            CreateMap<Permission, PermissionDTO>();
            CreateMap<UserToRole, UserToRoleDTO>();
            CreateMap<UserToRoleDTO, UserToRole>();
            CreateMap< UserToRole,UserToRoleDetailDTO>();
        }
    }
}