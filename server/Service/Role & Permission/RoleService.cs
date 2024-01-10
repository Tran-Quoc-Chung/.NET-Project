using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.middlewares;
using server.Models;

namespace server.Service;

public class RoleService : IRoleService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly AuthJwtToken _authJwtToken;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public RoleService(IMapper mapper, DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _authJwtToken = authJwtToken;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task<ServiceResponse<RoleDTO>> GetRoleById(int id)
    {

        var serviceResponse = new ServiceResponse<RoleDTO>();
        var dbRole = await _dataContext.Roles.Include(x=>x.CreatedBy).FirstOrDefaultAsync(x => x.RoleID == id);
        var result = new RoleDTO
        {
            RoleID = dbRole.RoleID,
            RoleName = dbRole.RoleName,
            RoleDescription = dbRole.RoleDescription,
            CreatedBy = dbRole.CreatedBy.DisplayName,
            CreatedAt = dbRole.CreatedAt.ToString("dd/MM/yyyy")
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<RoleDTO>>> GetAllRole()
    {
        var serviceResponse = new ServiceResponse<List<RoleDTO>>();
        var dbRole = await _dataContext.Roles.Include(x=>x.CreatedBy).ToListAsync();
        var result = dbRole.Select(x => new RoleDTO
        {
            RoleID = x.RoleID,
            RoleName = x.RoleName,
            RoleDescription = x.RoleDescription,
            CreatedBy = x.CreatedBy.DisplayName,
            CreatedAt = x.CreatedAt.ToString("dd/MM/yyyy")
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<RoleDTO>>> CreateNewRole(RoleDTO addRoleDTO)
    {
        var serviceResponse = new ServiceResponse<List<RoleDTO>>();
        var token= _httpContextAccessor.HttpContext.Request.Cookies["user"];
        var userID = _authJwtToken.ValidateToken(token);
        var userInfo = await _dataContext.Users.SingleOrDefaultAsync(x => x.UserID == userID.UserID);
        var role = _mapper.Map<Role>(addRoleDTO);
        role.CreatedBy = userInfo;
        role.CreatedAt = DateTime.Now;
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
        try
        {
            var Role = await _dataContext.Roles.FirstOrDefaultAsync(c => c.RoleID == updateRoleDTO.RoleID);
            if (Role is null)
                throw new Exception("Update status active false");

            Role.RoleName = updateRoleDTO.RoleName;
            Role.RoleDescription = updateRoleDTO.RoleDescription;
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<RoleDTO>(Role);
        }
        catch
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<RoleDTO>>> DeleteRole(int id)
    {
        var serviceResponse = new ServiceResponse<List<RoleDTO>>();
        try
        {
            var Role = await _dataContext.Roles.FirstOrDefaultAsync(c => c.RoleID == id);
            if (Role is null)
                throw new Exception("ID role not found");
            _dataContext.Roles.Remove(Role);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.Roles.Select(x => _mapper.Map<RoleDTO>(x)).ToListAsync();
            serviceResponse.Success = true;
            serviceResponse.Message = "Delete role successfully";
        }
        catch
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }
}