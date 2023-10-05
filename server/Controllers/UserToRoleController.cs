using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Service;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserToRoleController : ControllerBase
{
    private readonly IUserToRoleService _UserToRoleService;
    public UserToRoleController(IUserToRoleService UserToRoleService)
    {
        //_dataContext = dataContext;
        _UserToRoleService = UserToRoleService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<UserToRoleDetailDTO>>>> GetAllUserToRole()
    {
        //ServiceResponse<List<>>
        try
        {
            return await _UserToRoleService.GetAllUserToRole();
        }
        catch (Exception ex)
        {
            return BadRequest(new { messenger = "Get all UserToRole failed", err = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<UserToRoleDetailDTO>>> GetSingle(int id)
    {
        try
        {
            return await _UserToRoleService.GetRoleByUserId(id);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Get single UserToRole faile", err = ex.Message });
        }
    }

    [HttpPost("createnew")]
    public async Task<ActionResult<ServiceResponse<List<UserToRoleDTO>>>> CreateNew(UserToRoleDTO UserToRoleDTO)
    {
        try
        {
            return await _UserToRoleService.CreateNewUserToRole(UserToRoleDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Create UserToRole faile", err = ex.Message });
        }
    }

    [HttpPut("update")]

    public async Task<ActionResult<ServiceResponse<UserToRoleDTO>>> UpdateUserToRole(UserToRoleDTO UserToRoleDTO)
    {
        var response = await _UserToRoleService.UpdateUserToRole(UserToRoleDTO);
        if (response.Data == null || response.Success == false)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<ServiceResponse<UserToRoleDTO>>> DeleteUserToRole(int id)
    {
        var response = await _UserToRoleService.DeleteUserToRole(id);
        if (response.Data == null || response.Success == false)
        {
            return NotFound(response);
        }
        return Ok(new { message = "Delete UserToRole successfully", ListStatus = response });
    }

}