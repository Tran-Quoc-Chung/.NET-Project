using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Service;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PermissionController : ControllerBase
{
    private readonly IPermissionService _PermissionService;
    public PermissionController(IPermissionService PermissionService)
    {
        //_dataContext = dataContext;
        _PermissionService = PermissionService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<PermissionDTO>>>> GetAllPermission()
    {
        try
        {
            return await _PermissionService.GetAllPermission();
        }
        catch (Exception ex)
        {
            return BadRequest(new { messenger = "Get all Permission failed", err = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<PermissionDTO>>> GetSingle(int id)
    {
        try
        {
            return await _PermissionService.GetPermissionById(id);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Get all Permission faile", err = ex.Message });
        }
    }

    [HttpPost("createnew")]
    public async Task<ActionResult<ServiceResponse<List<PermissionDTO>>>> CreateNew(PermissionDTO PermissionDTO)
    {
        try
        {
            return await _PermissionService.CreateNewPermission(PermissionDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Create Permission faile", err = ex.Message });
        }
    }

    [HttpPut("update/{id}")]

    public async Task<ActionResult<ServiceResponse<PermissionDTO>>> UpdatePermission(PermissionDTO permissionDTO, int id)
    {
        if (id == 0)
        {
            return NotFound("Not found ID");
        }
        permissionDTO.PermissionID = id;
        try
        {
            var response = await _PermissionService.UpdatePermission(permissionDTO);

            if (response.Data == null || !response.Success)
            {
                return NotFound(response);
            }

            return response;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<ServiceResponse<PermissionDTO>>> DeletePermission(int id)
    {
        var response = await _PermissionService.DeletePermission(id);
        if (response.Data == null || response.Success == false)
        {
            return NotFound(response);
        }
        return Ok(new { message = "Delete Permission successfully", ListStatus = response });
    }

}