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
public class ProductController : ControllerBase
{
    private readonly IProductService _ProductService;
    public ProductController(IProductService ProductService)
    {
        //_dataContext = dataContext;
        _ProductService = ProductService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetAllProductDTO>>>> GetAllProduct()
    {
        try
        {
            
            return await _ProductService.GetAll();
        }
        catch (Exception ex)
        {
            return BadRequest(new { messenger = "Get all product failed", err = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<ProductResponseDTO>>> GetSingle(int id)
    {
        try
        {
            return await _ProductService.GetProductByID(id);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Get product failed", err = ex.Message });
        }
    }

    [HttpPost("getall")]
    public async Task<ActionResult<ServiceResponse<ProductClientDTO>>> getAllFromClient(PaginationDTO paginationDTO)
    {
        try
        {
            return Ok(await _ProductService.GetAllFromClient(paginationDTO));
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
            throw;
        }
    }


    //[Authorize( Policy="CreateRole")]
    [HttpPost("createnew")]
    public async Task<ActionResult<ServiceResponse<List<AddProductDTO>>>> CreateNew( [FromForm]AddProductDTO AddProductDTO)
    {
        try
        {
            List<IFormFile> imageFiles = HttpContext.Request.Form.Files.ToList();
            foreach (var item in imageFiles)
            {
                Console.WriteLine("item" + item.FileName);
            }
            return await _ProductService.Create(AddProductDTO, imageFiles);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Create product failed", err = ex });
        }
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<ServiceResponse<AddProductDTO>>> Update([FromForm]AddProductDTO AddProductDTO, int id, [FromForm]List<IFormFile> newImages,[FromForm]List<int> newImagesID)
    {
        if (id != 0)
        {
            AddProductDTO.ProductID = id;
        }
        else
        {
            return NotFound("Not found ID");
        }

        var response = await _ProductService.Update(AddProductDTO,newImages,newImagesID);
        if (response.Data == null || response.Success == false)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<ServiceResponse<Product>>> Delete(int id)
    {
        var response = await _ProductService.Delete(id);
        if ( response.Success == false)
        {
            return NotFound(response);
        }
        return Ok(new { message = "Delete Role successfully", ListStatus = response });
    }

    

}