using server.DTO;
using server.DTO.User;
using server.Models;

namespace service.Service
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDTO>> CreateNewUser(AddUserDTO addUserDTO);
        Task<ServiceResponse<GetUserDTO>> UserLogin(LoginUserDTO loginUserDTO);
        Task<ServiceResponse<List<GetUserDTO>>> GetAllUser();
        Task<ServiceResponse<GetUserDTO>> GetUserByEmail(string email);
        Task<ServiceResponse<GetUserDTO>> ResetPassword(string token,string password);
    }
}