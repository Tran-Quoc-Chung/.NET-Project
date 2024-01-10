using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.Models;

namespace server.Service;

public class RoleToPermissionService : IRoleToPermissionService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IRoleService _roleService;
    public readonly IPermissionService _permissionService;
    public RoleToPermissionService(IMapper mapper, DataContext dataContext, IRoleService roleService, IPermissionService permissionService)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _roleService = roleService;
        _permissionService = permissionService;
    }
    public async Task<ServiceResponse<RoleToPermissionDetailDTO>> CreateRoleToPermission(RoleToPermissionDTO roleToPermissionDTO)
    {
         var serviceResponse = new ServiceResponse<RoleToPermissionDetailDTO>();
        try
        {
        
        var existRoleToPermission = await _dataContext.RoleToPermissions
        .Where(x => x.RoleID == roleToPermissionDTO.RoleID)
        .ToListAsync();
          _dataContext.RoleToPermissions.RemoveRange(existRoleToPermission);

        // Thêm quyền mới vào cơ sở dữ liệu với từng PermissionID từ danh sách
        foreach (var permissionId in roleToPermissionDTO.PermissionID)
        {
            var roleToPermission = new RoleToPermission
            {
                RoleID = roleToPermissionDTO.RoleID,
                PermissionID = permissionId
            };
            await _dataContext.RoleToPermissions.AddAsync(roleToPermission);
        }
        await _dataContext.SaveChangesAsync();
        serviceResponse.Success = true;
            serviceResponse.Message = "Cập nhật vai trò thành công";
        }
        catch (System.Exception ex)
        {
        serviceResponse.Success = true;
        serviceResponse.Message = "Cập nhật vai trò thất bại: "+ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<RoleToPermissionDetailDTO>> GetAllPermissionByRoleID(int RoleID)
    {
        var serviceResponse = new ServiceResponse<RoleToPermissionDetailDTO>();

        // Lấy danh sách RoleToPermission dựa trên RoleID
        var listPermission = await _dataContext.RoleToPermissions
            .Include(x => x.Role).Include(x => x.Permission)
            .Where(c => c.RoleID == RoleID)
            .ToListAsync();

        // Kiểm tra xem có RoleToPermission nào không
        if (listPermission != null && listPermission.Any())
        {
            // Tạo đối tượng RoleToPermissionDetailDTO
            var result = new RoleToPermissionDetailDTO
            {
                RoleName = listPermission.First().Role.RoleName, // Lấy RoleName từ Role đầu tiên
                PermissionName = listPermission.Select(item => item.Permission.PermissionName).ToList(),
                PermissionID = listPermission.Select(item => item.Permission.PermissionID).ToList()
            };

            serviceResponse.Data = result;
            serviceResponse.Success = true;
        }
        else
        {
            serviceResponse.Message = "Permission not found.";
            serviceResponse.Data = new RoleToPermissionDetailDTO
            {
                RoleName = "",
                PermissionName = new List<string>(),
                PermissionID = new List<int>()
            };


        }

        return serviceResponse;
    }

}