using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using server.DTO;
using server.DTO.StatusActive;
using server.DTO.User;
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
        }
    }
}