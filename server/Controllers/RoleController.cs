using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Service;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _RoleService;
    public RoleController(IRoleService RoleService)
    {
        //_dataContext = dataContext;
        _RoleService = RoleService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<RoleDTO>>>> GetAllRole()
    {
        //ServiceResponse<List<>>
        try
        {
            
            return await _RoleService.GetAllRole();
        }
        catch (Exception ex)
        {
            return BadRequest(new { messenger = "Get all Role failed", err = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<RoleDTO>>> GetSingle(int id)
    {
        try
        {
            return await _RoleService.GetRoleById(id);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Get all Role faile", err = ex.Message });
        }
    }

    //[Authorize( Policy="CreateRole")]
    [HttpPost("createnew")]
    public async Task<ActionResult<ServiceResponse<List<RoleDTO>>>> CreateNew(RoleDTO RoleDTO)
    {
        try
        {
            return await _RoleService.CreateNewRole(RoleDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Create Role failed", err = ex.Message });
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<ServiceResponse<RoleDTO>>> UpdateRole(RoleDTO RoleDTO, int id)
    {
        if (id != 0)
        {
            RoleDTO.RoleID = id;
        }
        else
        {
            return NotFound("Not found ID");
        }
        var response = await _RoleService.UpdateRole(RoleDTO);
        if (response.Data == null || response.Success == false)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<ServiceResponse<RoleDTO>>> DeleteRole(int id)
    {
        var response = await _RoleService.DeleteRole(id);
        if (response.Data == null || response.Success == false)
        {
            return NotFound(response);
        }
        return Ok(new { message = "Delete Role successfully", ListStatus = response });
    }

}