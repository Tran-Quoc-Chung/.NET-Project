
using server.DTO;
using server.Models;

namespace server.Service{
    public interface IOriginalService
    {
        Task<ServiceResponse<GetOriginalDTO>> GetOriginalById(int id);
        Task<ServiceResponse<List<GetOriginalDTO>>> GetAllOriginal();
        Task<ServiceResponse<List<GetOriginalDTO>>> CreateNewOriginal(AddOriginalDTO addOriginalDTO);
        Task<ServiceResponse<GetOriginalDTO>> UpdateOriginal(UpdateOriginalDTO updateOriginalDTO);
        Task<ServiceResponse<List<GetOriginalDTO>>> DeleteOriginal(int id);
    }
}