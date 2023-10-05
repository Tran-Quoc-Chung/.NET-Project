using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Service;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleToPermissionController : ControllerBase
{
    private readonly IRoleToPermissionService _RoleToPermission;
    public RoleToPermissionController(IRoleToPermissionService RoleToPermission)
    {
        //_dataContext = dataContext;
        _RoleToPermission = RoleToPermission;
    }

    [HttpPost("createnew")]
    public async Task<ActionResult<ServiceResponse<RoleToPermissionDetailDTO>>> CreateNew(RoleToPermissionDTO roleToPermissionDTO)
    {
        try
        {
            return await _RoleToPermission.CreateRoleToPermission(roleToPermissionDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Create UserToRole faile", err = ex.Message });
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<RoleToPermissionDetailDTO>>> GetPermissionByRoleID(int id)
    {
        try
        {
            return await _RoleToPermission.GetAllPermissionByRoleID(id);
        }
        catch (System.Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    
}