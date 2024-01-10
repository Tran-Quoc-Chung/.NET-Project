using server.DTO;
using server.Models;

namespace server.Service{
    public interface IBrandService
    {
        Task<ServiceResponse<BrandDTO>> GetBrandById(int id);
        Task<ServiceResponse<List<BrandDTO>>> GetAllBrand();
        Task<ServiceResponse<List<BrandDTO>>> CreateNewBrand(BrandDTO addBrandDTO);
        Task<ServiceResponse<BrandDTO>> UpdateBrand(BrandDTO updateBrandDTO);
        Task<ServiceResponse<List<BrandDTO>>> DeleteBrand(int id);
    }
}