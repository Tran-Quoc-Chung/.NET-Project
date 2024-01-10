using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.DTO;
using server.DTO.User;
using server.DTO.Voucher;
using server.middlewares;
using server.Models;
using server.Service;
using server.Service.Products;
using server.Services;
using service.Service;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VoucherController : ControllerBase
{
    private readonly IVoucherService _voucherService;
    private readonly IConfiguration _configuration;
    private readonly AuthJwtToken _authJwtToken;
    public VoucherController(IVoucherService VoucherService,IConfiguration configuration, AuthJwtToken authJwtToken)
    {
        _voucherService = VoucherService;
        _configuration = configuration;
        _authJwtToken = authJwtToken;
    }

    [HttpPost("create")]
    public async Task<ActionResult<ServiceResponse<GetVoucherDTO>>> Create(AddVoucherDTO addInventoryDTO)
    {
        try
        {
            var newVoucher =await _voucherService.Create(addInventoryDTO);
            return Ok(newVoucher);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Create inventory failed", err = ex.Message });
        }
    }
    [HttpGet("{code}")]
    public async Task<ActionResult<ServiceResponse<GetVoucherDTO>>> GetByCode(string code)
    {
        try
        {
            var voucher = await _voucherService.GetVoucherByCode(code);
            return voucher;
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Get voucher failed", err = ex.Message });
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetVoucherDTO>>>> GetAll()
    {
        try
        {
            return await _voucherService.GetAllVoucher();
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    
    [HttpPut("update")]
    public async Task<ActionResult<ServiceResponse<GetVoucherDTO>>> Update(AddVoucherDTO addVoucherDTO)
    {
        try
        {
            return await _voucherService.UpdateVoucher(addVoucherDTO);
        }
        catch (Exception ex)
        {
           return BadRequest(new { message = "Update voucher failed", err = ex.Message });
        }
    }

    [HttpDelete("delete/{code}")]
    public async Task<ActionResult<ServiceResponse<GetVoucherDTO>>> Delete(string code)
    {
        try
        {
            return await _voucherService.DeleteVoucher(code);
        }
        catch (Exception ex)
        {
           return BadRequest(new { message = "Update voucher failed", err = ex.Message });
        }
    }
}   
