using System;
using server.DTO;
using server.Models;

namespace server.Service.Products
{
    public interface IInventoryService{
        Task<ServiceResponse<GetInventoryDTO>> Create(AddInventoryDTO addInventoryDTO);

        // Task<ServiceResponse<List<Product>>> GetAll();
         Task<ServiceResponse<GetInventoryDTO>> GetByID(int id);
         Task<ServiceResponse<List<GetAllInventoryDTO>>> GetAll();

        // Task<ServiceResponse<List<AddProductDTO>>> Create(AddProductDTO addProductDTO,List<IFormFile> imageFile);

        // Task<ServiceResponse<AddProductDTO>> Update(AddProductDTO addProductDTO,List<IFormFile> newImages,List<int> newImagesID);

        // Task<ServiceResponse<List<Product>>> Delete(int id);
    }
}