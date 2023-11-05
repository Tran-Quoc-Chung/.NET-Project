using System;
using server.DTO;
using server.Models;

namespace server.Service.Products
{
    public interface IProductService{
        Task<ServiceResponse<GetProductDTO>> GetProductByID (int id);

        Task<ServiceResponse<List<GetProductDTO>>> GetAllProduct ();

        Task<ServiceResponse<List<GetProductDTO>>> CreateNewProduct (AddProductDTO addProductDTO);

        Task<ServiceResponse<GetProductDTO>> UpdateProduct (UpdateProductDTO addProductDTO);

        Task<ServiceResponse<List<GetProductDTO>>> DeleteProduct (int id);
    }
}