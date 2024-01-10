using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTO;
using server.Models;
using server.Service;
using server.Service.Products;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;
    public InvoiceController(IInvoiceService InvoiceService)
    {
        _invoiceService = InvoiceService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<ServiceResponse<GetInvoiceDTO>>> Create( AddInvoiceDTO addInvoiceDTO)
    {
        try
        {
            return await _invoiceService.Create(addInvoiceDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Create invoice failed", err = ex.Message });
        }
    }
    [HttpPut("update/{status}/{id}")]
    public async Task<ActionResult<ServiceResponse<GetInvoiceDTO>>> Update(string status, int id)
    {
        try
        {
            return await _invoiceService.Update(status,id);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Update invoice failed", err = ex.Message });
        }
    }

    [HttpGet("filter/{id}")]
    public async Task<ActionResult<ServiceResponse<List<GetInvoiceDTO>>>> GetAll(int id)
    {
        try
        {
            return await _invoiceService.GetAll(id);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Get invoice failed", err = ex.Message });
        }
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<InvoiceDTO>>> GetByID(int id)
    {
        try
        {
            return await _invoiceService.GetInvoiceById(id);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Get invoice failed", err = ex.Message });
        }
    }

}