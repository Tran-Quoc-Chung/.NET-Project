using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.Models;

namespace server.Service;

public class UserToRoleService : IUserToRoleService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public UserToRoleService(IMapper mapper, DataContext dataContext)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<UserToRoleDetailDTO>> GetRoleByUserId(int id)
    {

        var serviceResponse = new ServiceResponse<UserToRoleDetailDTO>();
        var dbUserToRole = await _dataContext.UserToRoles.Include(u => u.Role).Include(u => u.User).Where(x=>x.UserID==id).FirstOrDefaultAsync();
        if(dbUserToRole is null){
            serviceResponse.Message = "Không tìm thấy người dùng có ID trên";
            serviceResponse.Success = false;
        }
        serviceResponse.Data = new UserToRoleDetailDTO
        {
            UserName = dbUserToRole.User.DisplayName,
            RoleName = dbUserToRole.Role.RoleName,
            RoleID =dbUserToRole.RoleID
        };
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<UserToRoleDetailDTO>>> GetAllUserToRole()
    {
        var serviceResponse = new ServiceResponse<List<UserToRoleDetailDTO>>();
        var dbUserToRole = await _dataContext.UserToRoles.Include(u => u.Role).Include(u => u.User).ToListAsync();

        serviceResponse.Data = dbUserToRole.Select(x => new UserToRoleDetailDTO
        {
            RoleID = x.RoleID,
            UserID = x.UserID,
            UserName = x.User.DisplayName,
            RoleName = x.Role.RoleName
        }).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<UserToRoleDTO>>> CreateNewUserToRole(UserToRoleDTO addUserToRoleDTO)
    {
        var serviceResponse = new ServiceResponse<List<UserToRoleDTO>>();
        var UserToRole = _mapper.Map<UserToRole>(addUserToRoleDTO);
        _dataContext.UserToRoles.Add(UserToRole);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await _dataContext.UserToRoles.Select(x => _mapper.Map<UserToRoleDTO>(x)).ToListAsync();
        serviceResponse.Success = true;
        serviceResponse.Message = "Create new UserToRole successfully";
        return serviceResponse;
    }

    public async Task<ServiceResponse<UserToRoleDTO>> UpdateUserToRole(UserToRoleDTO updateUserToRoleDTO)
    {
        var serviceResponse = new ServiceResponse<UserToRoleDTO>();
        try
        {
            var userToRole = await _dataContext.UserToRoles.FirstOrDefaultAsync(c => c.UserID == updateUserToRoleDTO.UserID);
            if (userToRole is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Update user to role false";
                return serviceResponse;
            }

            _dataContext.UserToRoles.Remove(userToRole);

            var newUserToRole = new UserToRole()
            {
                UserID = updateUserToRoleDTO.UserID,
                RoleID = updateUserToRoleDTO.RoleID
            };
            _dataContext.UserToRoles.Add(newUserToRole);
            await _dataContext.SaveChangesAsync();

            serviceResponse.Data = _mapper.Map<UserToRoleDTO>(newUserToRole);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed err:" + ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<UserToRoleDTO>>> DeleteUserToRole(int id)
    {
        var serviceResponse = new ServiceResponse<List<UserToRoleDTO>>();
        try
        {
            var UserToRole = await _dataContext.UserToRoles.FirstOrDefaultAsync(c => c.UserID == id);
            if (UserToRole is null)
                throw new Exception("ID UserToRole not found");
            _dataContext.UserToRoles.Remove(UserToRole);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.UserToRoles.Select(x => _mapper.Map<UserToRoleDTO>(x)).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Message = "Delete UserToRole successfully";
        }
        catch
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }
}