using server.DTO;
using server.DTO.User;
using server.Models;

namespace service.Service
{
    public interface ICustomerService
    {
        Task<ServiceResponse<AddCustomerDTO>> CreateNewCustomer(AddCustomerDTO addUserDTO);
        Task<ServiceResponse<GetUserDTO>> CustomerLogin(LoginUserDTO loginUserDTO);
        Task<ServiceResponse<AddCustomerDTO>> GetCustomerByEmail(string email);
        Task<ServiceResponse<GetUserDTO>> ResetPassword(string token,string password);
        Task<ServiceResponse<GetUserDTO>> GetCustomerById(int id);
        Task<ServiceResponse<GetUserDTO>> UpdateCustomer(GetUserDTO getUserDTO);
        Task<ServiceResponse<AddCustomerDTO>> GetCustomerInfoByToken();
        Task<ServiceResponse<CustomerCartDTO>> AddToCart(CartDetailDTO cartDetailDTO);
        Task<ServiceResponse<CustomerCartDTO>> GetCustomerCart();
        Task<ServiceResponse<CustomerCartDTO>> RemoveItemFromCart(int id);
        // Task<ServiceResponse<GetUserDTO>> CustomerOrder()
    }
}