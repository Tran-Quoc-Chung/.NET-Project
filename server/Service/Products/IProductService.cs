using System;
using server.DTO;
using server.Models;

namespace server.Service.Products
{
    public interface IProductService{
        Task<ServiceResponse<ProductResponseDTO>> GetProductByID(int id);

        Task<ServiceResponse<List<GetAllProductDTO>>> GetAll();

        Task<ServiceResponse<List<AddProductDTO>>> Create(AddProductDTO addProductDTO,List<IFormFile> imageFile);

        Task<ServiceResponse<AddProductDTO>> Update(AddProductDTO addProductDTO,List<IFormFile> newImages,List<int> newImagesID);

        Task<ServiceResponse<List<Product>>> Delete(int id);
        Task<ServiceResponse<ProductClientDTO>> GetAllFromClient(PaginationDTO paginationDTO);
        
    }
}