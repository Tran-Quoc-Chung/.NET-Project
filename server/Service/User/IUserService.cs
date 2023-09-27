using server.DTO;
using server.DTO.User;
using server.Models;

namespace service.Service
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDTO>> CreateNewUser(AddUserDTO addUserDTO);
        Task<ServiceResponse<LoginUserDTO>> UserLogin(LoginUserDTO loginUserDTO);
        Task<ServiceResponse<List<GetUserDTO>>> GetAllUser(); 
    }
}