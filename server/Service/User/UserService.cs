using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Security.Claims;
using AutoMapper;
using BCrypt.Net;
using CloudinaryDotNet.Actions;
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

                var passwordHash = BCrypt.Net.BCrypt.HashPassword(addUserDTO.Password);
                var checkStatusExist = await _dataContext.SystemStatus.FirstOrDefaultAsync(c => c.StatusID == addUserDTO.StatusActive);
                var checkGender = await _dataContext.Genders.FirstOrDefaultAsync(c => c.GenderID == addUserDTO.GenderID);
                if (checkStatusExist is null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Status active not exist";
                    return serviceResponse;
                }

                var newUser = _mapper.Map<User>(addUserDTO);
                newUser.Password = passwordHash;
                newUser.Status = checkStatusExist;
                newUser.Gender = checkGender;
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

        public async Task<ServiceResponse<List<GetAllUserDTO>>> GetAllUser()
        {
            var serviceResponse = new ServiceResponse<List<GetAllUserDTO>>();
            var dbUser = await _dataContext.Users.Include(u => u.Status).Include(u => u.Gender).ToListAsync();

            serviceResponse.Data = dbUser.Select(x => new GetAllUserDTO
            {
                UserID = x.UserID,
                Displayname = x.DisplayName,
                RoleName = _dataContext.UserToRoles.Where(item => item.UserID == x.UserID).Select(item => item.Role.RoleName).FirstOrDefault() ?? "",
                Status = x.Status.StatusName,
                Email = x.Email
            }).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetUserById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            var user = await _dataContext.Users.Include(u => u.Status).Include(u => u.Gender).FirstOrDefaultAsync(x => x.UserID == id);
            if (user is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Không tìm thấy dữ liệu người dùng";
                return serviceResponse;
            }
            var roleId = await _userToRoleService.GetRoleByUserId(user.UserID);
            var userInfo = new GetUserDTO()
            {
                UserID = user.UserID,
                Displayname = user.DisplayName,
                Email = user.Email,
                Phone = user.Phone!,
                Status = user.Status.StatusID,
                GenderID = user.Gender.GenderID,
                RoleID = roleId.Data.RoleID,
                Address = user.Address!
            };

            serviceResponse.Success = true;
            serviceResponse.Data = userInfo;
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetUserDTO>> UpdateUser(GetUserDTO getUserDTO)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            var newStatus = await _dataContext.SystemStatus.FirstOrDefaultAsync(x => x.StatusID == getUserDTO.Status);
            var newGender = await _dataContext.Genders.FirstOrDefaultAsync(x => x.GenderID == getUserDTO.GenderID);
            var newRole = await _dataContext.Roles.FirstOrDefaultAsync(x => x.RoleID == getUserDTO.RoleID);
            var userUpdate = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserID == getUserDTO.UserID);

            if (newStatus is null || newGender is null || newRole is null || userUpdate is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Dữ liệu không hợp lệ";
                return serviceResponse;
            }

            userUpdate.Email = getUserDTO.Email;
            userUpdate.Address = getUserDTO.Address;
            userUpdate.Phone = getUserDTO.Phone;
            userUpdate.DisplayName = getUserDTO.Displayname;
            userUpdate.Gender = newGender;
            userUpdate.Status = newStatus;

            //create new role
            var updateRole = new UserToRoleDTO
            {
                UserID = getUserDTO.UserID,
                RoleID = newRole.RoleID
            };
            await _userToRoleService.UpdateUserToRole(updateRole);

            await _dataContext.SaveChangesAsync();
            serviceResponse.Message = "Update successfully";
            serviceResponse.Success = true;
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetUserDTO>> DeleteUser(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();

            try
            {
                var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserID == id);
                if (user == null)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Người dùng không tồn tại.";
                    return serviceResponse;
                }
                var userToRoles = _dataContext.UserToRoles.Where(x => x.UserID == user.UserID).ToList();
                _dataContext.UserToRoles.RemoveRange(userToRoles);
                _dataContext.Users.Remove(user);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Success = true;
                serviceResponse.Message = "Xóa người dùng thành công";
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Lỗi khi xóa người dùng: " + ex.Message;
            }
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
                    serviceResponse.Message = "Không tìm thấy người dùng";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                if (user.Status.StatusID == 2)
                {
                    serviceResponse.Message = "Tài khoản đã ngừng kích hoạt";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                if (!BCrypt.Net.BCrypt.Verify(loginUserDTO.Password, user.Password))
                {
                    serviceResponse.Message = "Sai mật khẩu";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                var roleID = await _userToRoleService.GetRoleByUserId(user.UserID);

                var listPermission = await _roleToPermission.GetAllPermissionByRoleID(roleID.Data.RoleID);

                var userInfo = new GetUserDTO
                {
                    Email = user.Email,
                    Status = user.Status.StatusID,
                    Phone = user.Phone,
                    Displayname=user.DisplayName,
                    RoleID = roleID.Data.RoleID != null ? roleID.Data.RoleID : null,
                    ListPermission = listPermission.Data.PermissionID.ToList()
                };

                var authToken = _authJwtToken.CreateToken(userInfo.Email, user.UserID);
                var claims = listPermission.Data.PermissionName
                    .Select(permission => new Claim("Permission", permission)).ToList();

                var claimsIdentity = new ClaimsIdentity(claims, "custom");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await _httpContextAccessor.HttpContext.SignInAsync("Cookies", claimsPrincipal);
                _httpContextAccessor.HttpContext.Response.Cookies.Append("user", authToken, new CookieOptions
                {

                    IsEssential = true,
                    // HttpOnly = true, // Đảm bảo cookie chỉ có thể được đọc bởi máy chủ và không thể thay đổi từ phía máy khách.
                    SameSite = SameSiteMode.Lax, // Ngăn chặn việc gửi cookie trong các yêu cầu từ trang khác.
                    //  Secure = false, // Yêu cầu sử dụng kết nối an toàn (HTTPS) để truyền cookie.
                    Expires = DateTimeOffset.UtcNow.AddDays(1) 
                });

                serviceResponse.Data = userInfo;
                serviceResponse.Message = "Login successfully";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
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
                UserInfo userInfo = _authJwtToken.ValidateToken(token);
                var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == userInfo.Email);

                if (user is null)
                {
                    serviceResponse.Message = "User with this email not found";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                user.Password = passwordHash;
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