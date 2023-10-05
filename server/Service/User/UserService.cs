using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Security.Claims;
using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTO;
using server.DTO.User;
using server.middlewares;
using server.Models;
using service.Service;

namespace server.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly AuthJwtToken _authJwtToken;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserToRoleService _userToRoleService;
        private readonly IRoleToPermissionService _roleToPermission;
        public UserService(IMapper mapper, DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor, IUserToRoleService userToRoleService, IRoleToPermissionService roleToPermission)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _authJwtToken = authJwtToken;
            _httpContextAccessor = httpContextAccessor;
            _userToRoleService = userToRoleService;
            _roleToPermission = roleToPermission;
        }

        public async Task<ServiceResponse<GetUserDTO>> CreateNewUser(AddUserDTO addUserDTO)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            try
            {
                var existingUser = await GetUserByEmail(addUserDTO.Email);
                if (existingUser.Success == true)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Email already exists";
                    return serviceResponse;
                }

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
            var dbUser = await _dataContext.Users.Include(u => u.Status).ToListAsync();
            serviceResponse.Data = dbUser.Select(x => _mapper.Map<GetUserDTO>(x)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> UserLogin(LoginUserDTO loginUserDTO)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            //check user exist
            try
            {
                var user = await _dataContext.Users.Include(u => u.Status).FirstOrDefaultAsync(u => u.Email == loginUserDTO.Email);
                if (user is null)
                {
                    serviceResponse.Message = "User not exist or not found";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                if (user.Status.StatusID == 2)
                {
                    serviceResponse.Message = "Your account has been inactive";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                if (!BCrypt.Net.BCrypt.Verify(loginUserDTO.UserPassword, user.UserPassword))
                {
                    serviceResponse.Message = "User password is wrong";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                
                var roleID = await _userToRoleService.GetRoleByUserId(user.UserID);
                var listPermission = await _roleToPermission.GetAllPermissionByRoleID(roleID.Data.RoleID);
                var userInfo = new GetUserDTO
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Status = user.Status.StatusName,
                    Phone = user.Phone,
                    RoleID = roleID.Data.RoleID != null ? roleID.Data.RoleID : null
                };
                var claims = listPermission.Data.PermissionName
                    .Select(permission => new Claim("Permission", permission)).ToList();

                var claimsIdentity = new ClaimsIdentity(claims, "custom");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await _httpContextAccessor.HttpContext.SignInAsync("Cookies",claimsPrincipal);

                serviceResponse.Data = userInfo;
                serviceResponse.Message = "Login successfully";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                throw new Exception("Login exception. Err:" + ex.Message);
            }
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUserByEmail(string email)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            try
            {
                var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == email);

                if (user is null)
                {
                    serviceResponse.Message = "User with this email not found";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
                serviceResponse.Success = true;
                serviceResponse.Message = "User found successfully by email";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Error: " + ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> ResetPassword(string token, string password)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            try
            {
                string email = _authJwtToken.ValidateToken(token);
                var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == email);

                if (user is null)
                {
                    serviceResponse.Message = "User with this email not found";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                user.UserPassword = passwordHash;
                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
                serviceResponse.Success = true;
                serviceResponse.Message = "Reset password successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Error: " + ex.Message;
            }
            return serviceResponse;
        }
    }
}