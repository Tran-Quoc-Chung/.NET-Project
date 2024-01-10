
using server.DTO;
using server.Models;


namespace server.Service{
    public interface IDialShapeService
    {
        Task<ServiceResponse<DialShapeDTO>> GetById(int id);
        Task<ServiceResponse<List<DialShapeDTO>>> GetAll();
        Task<ServiceResponse<List<DialShapeDTO>>> Create(DialShapeDTO DialShapeDTO);
        Task<ServiceResponse<DialShapeDTO>> Update(DialShapeDTO update);
        Task<ServiceResponse<List<DialShapeDTO>>> Delete(int id);
    }
}