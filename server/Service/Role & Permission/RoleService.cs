using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.Models;

namespace server.Service;

public class RoleService : IRoleService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public RoleService(IMapper mapper, DataContext dataContext)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<RoleDTO>> GetRoleById(int id)
    {
        
        var serviceResponse = new ServiceResponse<RoleDTO>();
        var dbRole = await _dataContext.Roles.FirstOrDefaultAsync(x => x.RoleID == id);
        var result = new RoleDTO
        {
            RoleID = dbRole.RoleID,
            RoleName = dbRole.RoleName,
            RoleDescription = dbRole.RoleDescription
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<RoleDTO>>> GetAllRole()
    {
        var serviceResponse = new ServiceResponse<List<RoleDTO>>();
        var dbRole = await _dataContext.Roles.ToListAsync();
        var result = dbRole.Select(x => new RoleDTO
        {
            RoleID = x.RoleID,
            RoleName = x.RoleName,
            RoleDescription = x.RoleDescription
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<RoleDTO>>> CreateNewRole(RoleDTO addRoleDTO)
    {
        var serviceResponse = new ServiceResponse<List<RoleDTO>>();
        var role = _mapper.Map<Role>(addRoleDTO);
        _dataContext.Roles.Add(role);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await _dataContext.Roles.Select(x => _mapper.Map<RoleDTO>(x)).ToListAsync();
        serviceResponse.Success = true;
        serviceResponse.Message = "Create new role successfully";
        return serviceResponse;
    }

    public async Task<ServiceResponse<RoleDTO>> UpdateRole(RoleDTO updateRoleDTO)
    {
        var serviceResponse = new ServiceResponse<RoleDTO>();
        try{
              var Role = await _dataContext.Roles.FirstOrDefaultAsync(c => c.RoleID == updateRoleDTO.RoleID);
            if (Role is null)
                throw new Exception("Update status active false");
        
        Role.RoleName = updateRoleDTO.RoleName;
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<RoleDTO>(Role);
        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
      
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<RoleDTO>>> DeleteRole(int id)
    {
        var serviceResponse = new ServiceResponse<List<RoleDTO>>();
        try{
            var Role = await _dataContext.Roles.FirstOrDefaultAsync(c => c.RoleID == id);
            if(Role is null)
                throw new Exception("ID role not found");
            _dataContext.Roles.Remove(Role);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.Roles.Select(x => _mapper.Map<RoleDTO>(x)).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Message = "Delete role successfully";
        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }
}