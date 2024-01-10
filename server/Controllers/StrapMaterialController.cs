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
public class StrapMaterialController : ControllerBase
{
    private readonly IStrapMaterialService _strapMaterialService;
    public StrapMaterialController(IStrapMaterialService strapMaterialService)
    {
        //_dataContext = dataContext;
        _strapMaterialService = strapMaterialService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetStrapMaterialDTO>>>> GetAll()
    {
        try{
            return await _strapMaterialService.GetAll();
        }catch(Exception ex){
            return BadRequest(new { messenger = "Get all status active failed", err = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetStrapMaterialDTO>>> GetById(int id)
    {
       try{
        return await _strapMaterialService.GetById(id);
       }catch(Exception ex){
            return BadRequest(new { message = "Get all strapmaterial failed", err = ex.Message });
       }
    }

    [HttpPost("create")]
    public async Task<ActionResult<ServiceResponse<List<GetStrapMaterialDTO>>>> Create(GetStrapMaterialDTO getStrapMaterialDTO)
    {
        try{
            return await _strapMaterialService.Create(getStrapMaterialDTO);
        }catch(Exception ex){
            return BadRequest(new { message = "Create status active faile", err = ex.Message });
        }
    }

    [HttpPut("update")]

    public async Task<ActionResult<ServiceResponse<GetStrapMaterialDTO>>> Update(GetStrapMaterialDTO getStrapMaterialDTO)
    {
        var response = await _strapMaterialService.Update(getStrapMaterialDTO);
        if( response.Success==false)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<ServiceResponse<GetStrapMaterialDTO>>> Delete( int id)
    {
        var response = await _strapMaterialService.Delete(id);
        return Ok(response);
    }

}