using server.DTO;
using server.Models;

namespace server.Service{
    public interface IBrandService
    {
        Task<ServiceResponse<GetBrandDTO>> GetBrandById(int id);
        Task<ServiceResponse<List<GetBrandDTO>>> GetAllBrand();
        Task<ServiceResponse<List<GetBrandDTO>>> CreateNewBrand(AddBrandDTO addBrandDTO);
        Task<ServiceResponse<GetBrandDTO>> UpdateBrand(UpdateBrandDTO updateBrandDTO);
        Task<ServiceResponse<List<GetBrandDTO>>> DeleteBrand(int id);
    }
}