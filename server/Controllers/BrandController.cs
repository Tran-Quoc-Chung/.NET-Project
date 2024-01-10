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
public class BrandController : ControllerBase
{
    private readonly IBrandService _brandService;
    public BrandController(IBrandService brandService)
    {
        //_dataContext = dataContext;
        _brandService = brandService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<BrandDTO>>>> GetAll()
    {
        try{
            return await _brandService.GetAllBrand();
        }catch(Exception ex){
            return BadRequest(new { messenger = "Get all brand failed", err = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<BrandDTO>>> GetById(int id)
    {
       try{
        return await _brandService.GetBrandById(id);
       }catch(Exception ex){
            return BadRequest(new { message = "Get all brand failed", err = ex.Message });
       }
    }

    [HttpPost("create")]
    public async Task<ActionResult<ServiceResponse<List<BrandDTO>>>> Create(BrandDTO brandDTO)
    {
        try{
            return await _brandService.CreateNewBrand(brandDTO);
        }catch(Exception ex){
            return BadRequest(new { message = "Create brand failed", err = ex.Message });
        }
    }

    [HttpPut("update")]
    public async Task<ActionResult<ServiceResponse<BrandDTO>>> Update(BrandDTO brandDTO)
    {
        var response = await _brandService.UpdateBrand(brandDTO);
        if( response.Success==false)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<ServiceResponse<BrandDTO>>> Delete( int id)
    {
        var response = await _brandService.DeleteBrand(id);
        return Ok(response);
    }

}