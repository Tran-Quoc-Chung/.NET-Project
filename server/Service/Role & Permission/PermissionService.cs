using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.Models;

namespace server.Service;

public class PermissionService : IPermissionService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public PermissionService(IMapper mapper, DataContext dataContext)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<PermissionDTO>> GetPermissionById(int id)
    {

        var serviceResponse = new ServiceResponse<PermissionDTO>();
        var dbPermission = await _dataContext.Permissions.FirstOrDefaultAsync(x => x.PermissionID == id);
        serviceResponse.Data = _mapper.Map<PermissionDTO>(dbPermission);
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<PermissionDTO>>> GetAllPermission()
    {
        var serviceResponse = new ServiceResponse<List<PermissionDTO>>();
        var dbPermission = await _dataContext.Permissions.ToListAsync();
        serviceResponse.Data = dbPermission.Select(x => new PermissionDTO
        {
            PermissionID = x.PermissionID,
            PermissionName = x.PermissionName
        }).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<PermissionDTO>>> CreateNewPermission(PermissionDTO addPermissionDTO)
    {
        var serviceResponse = new ServiceResponse<List<PermissionDTO>>();
        var Permission = _mapper.Map<Permission>(addPermissionDTO);
        _dataContext.Permissions.Add(Permission);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await _dataContext.Permissions.Select(x => _mapper.Map<PermissionDTO>(x)).ToListAsync();
        serviceResponse.Success = true;
        serviceResponse.Message = "Create new Permission successfully";
        return serviceResponse;
    }

    public async Task<ServiceResponse<PermissionDTO>> UpdatePermission(PermissionDTO updatePermissionDTO)
    {
        var serviceResponse = new ServiceResponse<PermissionDTO>();
        var Permission = await _dataContext.Permissions.FirstOrDefaultAsync(c => c.PermissionID == updatePermissionDTO.PermissionID);
        if (Permission is null)
            throw new Exception("Update status active false");

        Permission.PermissionName = updatePermissionDTO.PermissionName;
        Permission.PermissionDescription = Permission.PermissionDescription != null ? updatePermissionDTO.PermissionDescription : Permission.PermissionDescription;
        await _dataContext.SaveChangesAsync();
        var result = new PermissionDTO
        {
            PermissionID = Permission.PermissionID,
            PermissionName = Permission.PermissionName,
            PermissionDescription = Permission.PermissionDescription
        };

        serviceResponse.Data = result;
        serviceResponse.Success = false;
        serviceResponse.Message = "Update failed";

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<PermissionDTO>>> DeletePermission(int id)
    {
        var serviceResponse = new ServiceResponse<List<PermissionDTO>>();
        try
        {
            var Permission = await _dataContext.Permissions.FirstOrDefaultAsync(c => c.PermissionID == id);
            if (Permission is null)
                throw new Exception("ID Permission not found");
            _dataContext.Permissions.Remove(Permission);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.Permissions.Select(x => _mapper.Map<PermissionDTO>(x)).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Message = "Delete Permission successfully";
        }
        catch
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }
}