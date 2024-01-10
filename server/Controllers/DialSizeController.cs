using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTO;
using server.DTO.DialSize;
using server.DTO.StatusActive;
using server.Models;
using server.Service;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DialSizeController : ControllerBase
{
    private readonly IDialSizeService _dialSizeService;
    public DialSizeController(IDialSizeService dialSizeService)
    {
        //_dataContext = dataContext;
        _dialSizeService = dialSizeService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<DialSizeDTO>>>> GetAll()
    {
        try{
            return await _dialSizeService.GetAll();
        }catch(Exception ex){
            return BadRequest(new { messenger = "Get all dial size failed", err = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<DialSizeDTO>>> GetById(int id)
    {
       try{
        return await _dialSizeService.GetById(id);
       }catch(Exception ex){
            return BadRequest(new { message = "Get all dial size failed", err = ex.Message });
       }
    }

    [HttpPost("create")]
    public async Task<ActionResult<ServiceResponse<List<DialSizeDTO>>>> Create(DialSizeDTO DialSizeDTO)
    {
        try{
            return await _dialSizeService.Create(DialSizeDTO);
        }catch(Exception ex){
            return BadRequest(new { message = "Create dial size failed", err = ex.Message });
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult<ServiceResponse<DialSizeDTO>>> Update(DialSizeDTO DialSizeDTO)
    {
        var response = await _dialSizeService.Update(DialSizeDTO);
        if( response.Success==false)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<ServiceResponse<DialSizeDTO>>> Delete( int id)
    {
        var response = await _dialSizeService.Delete(id);
        return Ok(response);
    }

}