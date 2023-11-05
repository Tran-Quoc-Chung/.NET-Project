using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO;

using server.Models;
using server.Service.Products;

namespace server.Service;

public class ProductService : IProductService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public ProductService(IMapper mapper, DataContext dataContext)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<GetProductDTO>> GetProductById(int id)
    {
        
        var serviceResponse = new ServiceResponse<GetProductDTO>();
        var dbProduct = await _dataContext.Products.FirstOrDefaultAsync(x => x.ProductID == id);
        var result = new GetProductDTO
        {
            ProductID = dbProduct.ProductID,
            ProductName = dbProduct.ProductName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetProductDTO>>> GetAllProduct()
    {
        var serviceResponse = new ServiceResponse<List<GetProductDTO>>();
        var dbProduct = await _dataContext.Products.ToListAsync();
        var result = dbProduct.Select(x => new GetProductDTO
        {
            ProductID = x.ProductID,
            ProductName = x.ProductName
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetProductDTO>>> CreateNewProduct(AddProductDTO addProductDTO)
    {
        var serviceResponse = new ServiceResponse<List<GetProductDTO>>();
        var Product = _mapper.Map<Product>(addProductDTO);
        _dataContext.Products.Add(Product);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await _dataContext.Products.Select(x => _mapper.Map<GetProductDTO>(x)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetProductDTO>> UpdateProduct(UpdateProductDTO updateProductDTO)
    {
        var serviceResponse = new ServiceResponse<GetProductDTO>();
        try{
              var Product = await _dataContext.Products.FirstOrDefaultAsync(c => c.ProductID == updateProductDTO.ProductID);
            if (Product is null)
                throw new Exception("Update product false");
        
        Product.ProductName = updateProductDTO.ProductName;
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetProductDTO>(Product);
        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
      
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetProductDTO>>> DeleteProduct(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetProductDTO>>();
        try{
            var Product = await _dataContext.Products.FirstOrDefaultAsync(c => c.ProductID == id);
            if(Product is null)
                throw new Exception("ID product not found");
            _dataContext.Products.Remove(Product);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.Products.Select(x => _mapper.Map<GetProductDTO>(x)).ToListAsync();

        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }

    public Task<ServiceResponse<GetProductDTO>> GetProductByID(int id)
    {
        throw new NotImplementedException();
    }
}