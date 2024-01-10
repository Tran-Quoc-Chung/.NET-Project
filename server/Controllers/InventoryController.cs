using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.Data;
using server.DTO;
using server.DTO.User;
using server.middlewares;
using server.Models;
using server.Service.Products;
using server.Services;
using service.Service;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;
    private readonly IConfiguration _configuration;
    private readonly AuthJwtToken _authJwtToken;
    public InventoryController(IInventoryService inventoryService,IConfiguration configuration,IMailService mail, AuthJwtToken authJwtToken)
    {
        _inventoryService = inventoryService;
        _configuration = configuration;
        _authJwtToken = authJwtToken;
    }

    [HttpPost("import")]
    public async Task<ActionResult<ServiceResponse<GetInventoryDTO>>> Create(AddInventoryDTO addInventoryDTO)
    {
        try
        {
            var newUser =await _inventoryService.Create(addInventoryDTO);
            return newUser;
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Create inventory failed", err = ex.Message });
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetInventoryDTO>>> GetByID(int id)
    {
        try
        {
            var inventory = await _inventoryService.GetByID(id);
            return inventory;
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Create inventory failed", err = ex.Message });
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetAllInventoryDTO>>>> GetAll()
    {
        try
        {
            return await _inventoryService.GetAll();
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    
}   
