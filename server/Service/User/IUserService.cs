using server.DTO;
using server.DTO.User;
using server.Models;

namespace service.Service
{
    public interface IUserService
    {
        Task<ServiceResponse<GetUserDTO>> CreateNewUser(AddUserDTO addUserDTO);
        Task<ServiceResponse<GetUserDTO>> UserLogin(LoginUserDTO loginUserDTO);
        Task<ServiceResponse<List<GetAllUserDTO>>> GetAllUser();
        Task<ServiceResponse<GetUserDTO>> GetUserByEmail(string email);
        Task<ServiceResponse<GetUserDTO>> ResetPassword(string token,string password);
        Task<ServiceResponse<GetUserDTO>> GetUserById(int id);
        Task<ServiceResponse<GetUserDTO>> UpdateUser(GetUserDTO getUserDTO);
        Task<ServiceResponse<GetUserDTO>> DeleteUser(int id);
    }
}