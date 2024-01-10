using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTO;
using server.DTO.StatusActive;
using server.Models;
using server.Service;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WaterResistanceController : ControllerBase
{
    private readonly IWaterResistanceService _waterResistanceService;
    public WaterResistanceController(IWaterResistanceService waterResistanceService)
    {
        //_dataContext = dataContext;
        _waterResistanceService = waterResistanceService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<WaterResistanceDTO>>>> GetAll()
    {
        try{
            return await _waterResistanceService.GetAll();
        }catch(Exception ex){
            return BadRequest(new { messenger = "Get all water resistance failed", err = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<WaterResistanceDTO>>> GetById(int id)
    {
       try{
        return await _waterResistanceService.GetById(id);
       }catch(Exception ex){
            return BadRequest(new { message = "Get all water resistance failed", err = ex.Message });
       }
    }

    [HttpPost("create")]
    public async Task<ActionResult<ServiceResponse<List<WaterResistanceDTO>>>> Create(WaterResistanceDTO WaterResistanceDTO)
    {
        try{
            return await _waterResistanceService.Create(WaterResistanceDTO);
        }catch(Exception ex){
            return BadRequest(new { message = "Create water resistance failed", err = ex.Message });
        }
    }

    [HttpPut("update")]

    public async Task<ActionResult<ServiceResponse<WaterResistanceDTO>>> Update(WaterResistanceDTO WaterResistanceDTO)
    {
        var response = await _waterResistanceService.Update(WaterResistanceDTO);
        if( response.Success==false)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<ServiceResponse<WaterResistanceDTO>>> Delete( int id)
    {
        var response = await _waterResistanceService.Delete(id);
        return Ok(response);
    }

}