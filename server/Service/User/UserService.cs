using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTO;
using server.DTO.User;
using server.Models;
using service.Service;

namespace server.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public UserService(IMapper mapper, DataContext dataContext)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetUserDTO>> CreateNewUser(AddUserDTO addUserDTO)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            try
            {
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(addUserDTO.UserPassword);
                var checkStatusExist = await _dataContext.StatusActives.FirstOrDefaultAsync(c => c.StatusID == addUserDTO.StatusActive);
                if (checkStatusExist is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Status active not exist";
                    return serviceResponse;
                }

                var newUser = _mapper.Map<User>(addUserDTO);
                newUser.UserPassword = passwordHash;
                newUser.Status = checkStatusExist;
                _dataContext.Users.Add(newUser);
                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserDTO>(newUser);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetUserDTO>>> GetAllUser()
        {
            var serviceResponse = new ServiceResponse<List<GetUserDTO>>();
            var dbUser = await _dataContext.Users.ToListAsync();
            Console.Write(dbUser);
            serviceResponse.Data = dbUser.Select(x => _mapper.Map<GetUserDTO>(x)).ToList();
            return serviceResponse;
        }
        public async Task<ServiceResponse<LoginUserDTO>> UserLogin(LoginUserDTO loginUserDTO)
        {
            var serviceResponse = new ServiceResponse<LoginUserDTO>();
            //check user exist
            try
            {
                var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserName == loginUserDTO.UserName);  
                if (user is null)
                {
                    serviceResponse.Message = "User not exist or not found";
                    serviceResponse.Success = false;
                    return serviceResponse;                }
                if (!BCrypt.Net.BCrypt.Verify( loginUserDTO.UserPassword,user.UserPassword))
                {
                    serviceResponse.Message = "User password is wrong";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                
                serviceResponse.Message = "Login successfully";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                throw new Exception( "Login exception. Err:"+ex.Message);
            }
        }
    }
}