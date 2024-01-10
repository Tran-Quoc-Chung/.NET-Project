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
public class DialShapeController : ControllerBase
{
    private readonly IDialShapeService _dialShapeService;
    public DialShapeController(IDialShapeService dialShapeService)
    {
        //_dataContext = dataContext;
        _dialShapeService = dialShapeService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<DialShapeDTO>>>> GetAll()
    {
        try{
            return await _dialShapeService.GetAll();
        }catch(Exception ex){
            return BadRequest(new { messenger = "Get all dial Shape failed", err = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<DialShapeDTO>>> GetById(int id)
    {
       try{
        return await _dialShapeService.GetById(id);
       }catch(Exception ex){
            return BadRequest(new { message = "Get all dial Shape failed", err = ex.Message });
       }
    }

    [HttpPost("create")]
    public async Task<ActionResult<ServiceResponse<List<DialShapeDTO>>>> Create(DialShapeDTO DialShapeDTO)
    {
        try{
            return await _dialShapeService.Create(DialShapeDTO);
        }catch(Exception ex){
            return BadRequest(new { message = "Create dial Shape failed", err = ex.Message });
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult<ServiceResponse<DialShapeDTO>>> Update(DialShapeDTO DialShapeDTO)
    {
        var response = await _dialShapeService.Update(DialShapeDTO);
        if( response.Success==false)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<ServiceResponse<DialShapeDTO>>> Delete( int id)
    {
        var response = await _dialShapeService.Delete(id);

        return Ok(response);
    }

}