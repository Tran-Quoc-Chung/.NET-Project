using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Security.Claims;
using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTO;
using server.DTO.User;
using server.middlewares;
using server.Models;
using service.Service;

namespace server.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly AuthJwtToken _authJwtToken;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserToRoleService _userToRoleService;
        private readonly IRoleToPermissionService _roleToPermission;
        public CustomerService(IMapper mapper, DataContext dataContext, AuthJwtToken authJwtToken, IHttpContextAccessor httpContextAccessor, IUserToRoleService userToRoleService, IRoleToPermissionService roleToPermission)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _authJwtToken = authJwtToken;
            _httpContextAccessor = httpContextAccessor;
            _userToRoleService = userToRoleService;
            _roleToPermission = roleToPermission;
        }

        public async Task<ServiceResponse<AddCustomerDTO>> CreateNewCustomer(AddCustomerDTO addCustomerDTO)
        {
            var serviceResponse = new ServiceResponse<AddCustomerDTO>();
            try
            {
                var existingCustomer = await GetCustomerByEmail(addCustomerDTO.Email);
                if (existingCustomer.Success == true)
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Email đã tồn tại";
                    return serviceResponse;
                }
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(addCustomerDTO.Password);

                var newCustomer = _mapper.Map<Customer>(addCustomerDTO);
                newCustomer.Password = passwordHash;
                _dataContext.Customers.Add(newCustomer);
                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<AddCustomerDTO>(newCustomer);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> GetCustomerById(int id)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            var user = await _dataContext.Users.Include(u => u.Status).Include(u => u.Gender).FirstOrDefaultAsync(x => x.UserID == id);
            if (user is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Không tìm thấy dữ liệu người dùng";
                return serviceResponse;
            }
            var roleId = await _userToRoleService.GetRoleByUserId(user.UserID);
            var userInfo = new GetUserDTO()
            {
                UserID = user.UserID,
                Displayname = user.DisplayName,
                Email = user.Email,
                Phone = user.Phone!,
                Status = user.Status.StatusID,
                GenderID = user.Gender.GenderID,
                RoleID = roleId.Data.RoleID,
                Address = user.Address!
            };

            serviceResponse.Success = true;
            serviceResponse.Data = userInfo;
            return serviceResponse;
        }

        public async Task<ServiceResponse<AddCustomerDTO>> GetCustomerInfoByToken()
        {
            var serviceResponse = new ServiceResponse<AddCustomerDTO>();
            var token = _httpContextAccessor.HttpContext.Request.Cookies["customer"];
            if(token is null )
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Token not found";
                return serviceResponse;
            }
            var userID = _authJwtToken.ValidateToken(token);
            var userInfo = await _dataContext.Customers.SingleOrDefaultAsync(x => x.CustomerID == userID.UserID);
            if(userInfo is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Not found customer info";
                return serviceResponse;
            }
            var result = new AddCustomerDTO
            {
                Email=userInfo.Email,
                DisplayName=userInfo.DisplayName,
                Phone=userInfo.Phone,
                Address=userInfo.Address
            };
            serviceResponse.Data = result;
            serviceResponse.Success = true;
            serviceResponse.Message = "Get customer info successfully";
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetUserDTO>> UpdateCustomer(GetUserDTO getUserDTO)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            var newStatus = await _dataContext.SystemStatus.FirstOrDefaultAsync(x => x.StatusID == getUserDTO.Status);
            var newGender = await _dataContext.Genders.FirstOrDefaultAsync(x => x.GenderID == getUserDTO.GenderID);
            var newRole = await _dataContext.Roles.FirstOrDefaultAsync(x => x.RoleID == getUserDTO.RoleID);
            var userUpdate = await _dataContext.Users.FirstOrDefaultAsync(x => x.UserID == getUserDTO.UserID);

            if (newStatus is null || newGender is null || newRole is null || userUpdate is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Dữ liệu không hợp lệ";
                return serviceResponse;
            }

            userUpdate.Email = getUserDTO.Email;
            userUpdate.Address = getUserDTO.Address;
            userUpdate.Phone = getUserDTO.Phone;
            userUpdate.DisplayName = getUserDTO.Displayname;
            userUpdate.Gender = newGender;
            userUpdate.Status = newStatus;

            //create new role
            var updateRole = new UserToRoleDTO
            {
                UserID = getUserDTO.UserID,
                RoleID = newRole.RoleID
            };
            await _userToRoleService.UpdateUserToRole(updateRole);

            await _dataContext.SaveChangesAsync();
            serviceResponse.Message = "Update successfully";
            serviceResponse.Success = true;
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetUserDTO>> CustomerLogin(LoginUserDTO loginUserDTO)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            //check user exist
            try
            {
                var user = await _dataContext.Customers.FirstOrDefaultAsync(u => u.Email == loginUserDTO.Email);
                if (user is null)
                {
                    serviceResponse.Message = "Không tìm thấy người dùng";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                if (!BCrypt.Net.BCrypt.Verify(loginUserDTO.Password, user.Password))
                {
                    serviceResponse.Message = "Sai mật khẩu";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                var userInfo = new GetUserDTO
                {
                    Email = user.Email,
                    Displayname = user.DisplayName
                };

                var authToken = _authJwtToken.CreateToken(userInfo.Email, user.CustomerID);

                _httpContextAccessor.HttpContext.Response.Cookies.Append("customer", authToken, new CookieOptions
                {
                    IsEssential = true,
                    // HttpOnly = true, // Đảm bảo cookie chỉ có thể được đọc bởi máy chủ và không thể thay đổi từ phía máy khách.
                    SameSite = SameSiteMode.Lax, // Ngăn chặn việc gửi cookie trong các yêu cầu từ trang khác.
                    //  Secure = false, // Yêu cầu sử dụng kết nối an toàn (HTTPS) để truyền cookie.
                    Expires = DateTimeOffset.UtcNow.AddDays(1)
                });

                serviceResponse.Data = userInfo;
                serviceResponse.Message = "Login successfully";
                serviceResponse.Success = true;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("Login exception. Err:" + ex.Message);
            }
        }

        public async Task<ServiceResponse<AddCustomerDTO>> GetCustomerByEmail(string email)
        {
            var serviceResponse = new ServiceResponse<AddCustomerDTO>();
            try
            {
                var customer = await _dataContext.Customers.FirstOrDefaultAsync(u => u.Email == email);

                if (customer is null)
                {
                    serviceResponse.Message = "User with this email not found";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }

                serviceResponse.Data = _mapper.Map<AddCustomerDTO>(customer);
                serviceResponse.Success = true;
                serviceResponse.Message = "User found successfully by email";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Error: " + ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetUserDTO>> ResetPassword(string token, string password)
        {
            var serviceResponse = new ServiceResponse<GetUserDTO>();
            try
            {
                UserInfo userInfo = _authJwtToken.ValidateToken(token);
                var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == userInfo.Email);

                if (user is null)
                {
                    serviceResponse.Message = "User with this email not found";
                    serviceResponse.Success = false;
                    return serviceResponse;
                }
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                user.Password = passwordHash;
                await _dataContext.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetUserDTO>(user);
                serviceResponse.Success = true;
                serviceResponse.Message = "Reset password successfully";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Error: " + ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<CustomerCartDTO>> AddToCart(CartDetailDTO cartDetailDTO)
        {
            var serviceResponse = new ServiceResponse<CustomerCartDTO>();
            var productInfo = await _dataContext.Products.FirstOrDefaultAsync(x => x.ProductID == cartDetailDTO.ProductId);

            if(productInfo is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Product not found";
                return serviceResponse;
            }
            if(productInfo.import_count - productInfo.sold_count <= 0)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Sản phẩm đã hết hàng";
                return serviceResponse;
            }
            var token = _httpContextAccessor.HttpContext.Request.Cookies["customer"];
            if(token is null )
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Token not found";
                return serviceResponse;
            }
            var userID = _authJwtToken.ValidateToken(token);
            var userInfo = await _dataContext.Customers.SingleOrDefaultAsync(x => x.CustomerID == userID.UserID);
            if(userInfo is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Not found customer info";
                return serviceResponse;
            }

            var cartCustomer = await _dataContext.Carts.FirstOrDefaultAsync(x => x.Customerid.CustomerID == userInfo.CustomerID);
            if(cartCustomer is null)
            {
                var cartCustomerNew = new Cart {
                    Customerid = userInfo,
                    TotalCart = 0
                };
                var cartInfo =  _dataContext.Carts.Add(cartCustomerNew);
                var cartDetail = new CartDetail
                {
                    Cartid = cartInfo.Entity,
                    Productid = productInfo,
                    Quantity = cartDetailDTO.Quantity ?? 1
                };
                 _dataContext.CartDetails.Add(cartDetail);
            }
            else
            {
                 var cartDetail = new CartDetail
                {
                    Cartid = cartCustomer,
                    Productid = productInfo,
                    Quantity = cartDetailDTO.Quantity ?? 1
                };
                 _dataContext.CartDetails.Add(cartDetail);

            }
            await _dataContext.SaveChangesAsync();
            serviceResponse.Success = true;
            serviceResponse.Message = "Thêm vào giỏ hàng thành công";

            return serviceResponse;

        }
        public async Task<ServiceResponse<CustomerCartDTO>> GetCustomerCart()
        {
            var serviceResponse = new ServiceResponse<CustomerCartDTO>();
            var token = _httpContextAccessor.HttpContext.Request.Cookies["customer"];
            if(token is null )
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Token not found";
                return serviceResponse;
            }
            var userID = _authJwtToken.ValidateToken(token);
            var userInfo = await _dataContext.Customers.SingleOrDefaultAsync(x => x.CustomerID == userID.UserID);
            if(userInfo is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Not found customer info";
                return serviceResponse;
            }
            var cartInfo = await _dataContext.Carts.FirstOrDefaultAsync(x => x.Customerid.CustomerID == userInfo.CustomerID) ?? null;
            if(cartInfo is null)
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }
            var cartList = await _dataContext.CartDetails.Include(x=>x.Productid).Include(x=>x.Cartid).Where(x => x.Cartid.CartID == cartInfo.CartID).ToListAsync();

            var listItem = cartList.Select(x => new CartDetailDTO
            {
                ProductId=x.Productid.ProductID,
                ProductName=x.Productid.ProductName,
                Price=x.Productid.SellPrice,
                Image=_dataContext.Images.Where(item => item.ImagesType == "Product").Where(item => item.Product.ProductID == x.Productid.ProductID).Select(item => item.ImagesUrl).FirstOrDefault() ?? "",
                Quantity=x.Quantity
            }).ToList();
            var result = new CustomerCartDTO
            {
                ListProduct=listItem
            };
            serviceResponse.Data = result;
            serviceResponse.Success = true;

            return serviceResponse;

        }
        public async Task<ServiceResponse<CustomerCartDTO>> RemoveItemFromCart(int productId)
        {
            var serviceResponse = new ServiceResponse<CustomerCartDTO>();
            var token = _httpContextAccessor.HttpContext.Request.Cookies["customer"];
            if(token is null )
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Token not found";
                return serviceResponse;
            }
            var userID = _authJwtToken.ValidateToken(token);
            var userInfo = await _dataContext.Customers.SingleOrDefaultAsync(x => x.CustomerID == userID.UserID);
            if(userInfo is null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Not found customer info";
                return serviceResponse;
            }
            var cartInfo = await _dataContext.Carts.FirstOrDefaultAsync(x => x.Customerid.CustomerID == userInfo.CustomerID) ?? null;
            if(cartInfo is null)
            {
                serviceResponse.Data = null;
                return serviceResponse;
            }
            var cartItem = await _dataContext.CartDetails.Include(x=>x.Productid).Include(x=>x.Cartid).Where(x => x.Cartid.CartID == cartInfo.CartID).Where(x=>x.Productid.ProductID==productId).ToListAsync();
            _dataContext.CartDetails.RemoveRange(cartItem);
            await _dataContext.SaveChangesAsync();
            
            serviceResponse.Success = true;

            return serviceResponse;

        }
    }
}