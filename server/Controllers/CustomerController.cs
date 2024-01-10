using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using server.Data;
using server.DTO;
using server.DTO.User;
using server.middlewares;
using server.Models;
using server.Services;
using service.Service;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IConfiguration _configuration;
    private readonly IMailService _mail;
    private readonly AuthJwtToken _authJwtToken;
    public CustomerController(ICustomerService customerService, IConfiguration configuration, IMailService mail, AuthJwtToken authJwtToken)
    {
        _customerService = customerService;
        _configuration = configuration;
        _mail = mail;
        _authJwtToken = authJwtToken;
    }

    [HttpPost("createnew")]
    public async Task<ActionResult<ServiceResponse<AddCustomerDTO>>> CreateNewUser(AddCustomerDTO addCustomerDTO)
    {
        try
        {
            var newUser = await _customerService.CreateNewCustomer(addCustomerDTO);
            return Ok(new { message = "Create new customer successfully", user = newUser });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Create customer failed", err = ex.Message });
        }
    }
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<ServiceResponse<GetUserDTO>>> UserLogin(LoginUserDTO loginUserDTO)
    {
        try
        {
            if (loginUserDTO.Email == null || loginUserDTO.Password == null)
            {
                return BadRequest("Email or user password not valid");
            }

            return await _customerService.CustomerLogin(loginUserDTO);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Login user failed", err = ex.Message });
        }

    }

    [HttpPost("forgotpassword")]
    public async Task<ActionResult<ServiceResponse<GetUserDTO>>> SendMailAsync(MailData mailData)
    {
        var checkUserExist = await _customerService.GetCustomerByEmail(mailData.To);
        if (checkUserExist.Success == false) return NotFound("User email not found");
        //mailData.Token = _authJwtToken.CreateToken(mailData.To, checkUserExist.Data.);
        Console.WriteLine(mailData.Token);
        //var result = await _mail.SendAsync(mailData, new CancellationToken());
        var result = true;
        if (result)
        {
            return Ok("Send mail successfully");
        }
        else
        {
            return BadRequest("Send mail failed. Try again!");
        }
    }

    [HttpPost("getCustomerInfo")]
    public async Task<ActionResult<ServiceResponse<AddCustomerDTO>>> GetCustomerInfo()
    {
        return await _customerService.GetCustomerInfoByToken();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceResponse<GetUserDTO>>> GetUserById(int id)
    {
        try
        {
            return await _customerService.GetCustomerById(id);
        }
        catch (Exception ex)
        {

            return BadRequest(new { message = "Get user info failed. try again!!", err = ex.Message });
        }
    }
    [HttpPut("resetpassword/{token}")]
    public async Task<ActionResult<ServiceResponse<GetUserDTO>>> ResetPassword(string token, LoginUserDTO loginUserDTO)
    {
        try
        {
            return await _customerService.ResetPassword(token, loginUserDTO.Password);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Get all user failed", err = ex.Message });
        }
    }

    [HttpPut("update-user")]
    public async Task<ActionResult<ServiceResponse<GetUserDTO>>> UpdateUser(GetUserDTO getUserDTO)
    {
        try
        {
            return await _customerService.UpdateCustomer(getUserDTO);
        }
        catch (Exception ex)
        {

            return BadRequest(new { message = "Update user failed. Try again!!", err = ex.Message });
        }
    }
    [HttpPost("addtocart")]
    public async Task<ActionResult<ServiceResponse<CustomerCartDTO>>> AddToCart(CartDetailDTO cartDetailDTO)
    {
        try
        {
            return await _customerService.AddToCart(cartDetailDTO);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    [HttpGet("getcartlist")]
    public async Task<ActionResult<ServiceResponse<CustomerCartDTO>>> GetCustomerCart()
    {
        try
        {
            return await _customerService.GetCustomerCart();
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
    [HttpDelete("remove-item/{id}")]
    public async Task<ActionResult<ServiceResponse<CustomerCartDTO>>> RemoveCartItem(int id)
    {
        try
        {
            return await _customerService.RemoveItemFromCart(id);
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }
}
