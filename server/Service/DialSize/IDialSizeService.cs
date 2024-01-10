using server.DTO.DialSize;
using server.Models;


namespace server.Service{
    public interface IDialSizeService
    {
        Task<ServiceResponse<DialSizeDTO>> GetById(int id);
        Task<ServiceResponse<List<DialSizeDTO>>> GetAll();
        Task<ServiceResponse<List<DialSizeDTO>>> Create(DialSizeDTO DialSizeDTO);
        Task<ServiceResponse<DialSizeDTO>> Update(DialSizeDTO update);
        Task<ServiceResponse<List<DialSizeDTO>>> Delete(int id);
    }
}