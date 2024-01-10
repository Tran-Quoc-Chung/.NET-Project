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
public class PartnerController : ControllerBase
{
    private readonly IPartnerService _partnerService;
    public PartnerController(IPartnerService partnerService)
    {
        //_dataContext = dataContext;
        _partnerService = partnerService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<PartnerDTO>>>> GetAll()
    {
        try{
            return await _partnerService.GetAll();
        }catch(Exception ex){
            return BadRequest(new { messenger = "Get all partner failed", err = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<PartnerDTO>>> GetById(int id)
    {
       try{
        return await _partnerService.GetById(id);
       }catch(Exception ex){
            return BadRequest(new { message = "Get all partner failed", err = ex.Message });
       }
    }

    [HttpPost("create")]
    public async Task<ActionResult<ServiceResponse<List<PartnerDTO>>>> Create(PartnerDTO PartnerDTO)
    {
        try{
            return await _partnerService.Create(PartnerDTO);
        }catch(Exception ex){
            return BadRequest(new { message = "Create partner failed", err = ex.Message });
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult<ServiceResponse<PartnerDTO>>> Update(PartnerDTO PartnerDTO)
    {
        var response = await _partnerService.Update(PartnerDTO);
        if( response.Success==false)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<ServiceResponse<PartnerDTO>>> Delete( int id)
    {
        var response = await _partnerService.Delete(id);
        return Ok(response);
    }

}