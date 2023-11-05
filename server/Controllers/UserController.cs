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
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private readonly IMailService _mail;
    private readonly AuthJwtToken _authJwtToken;
    public UserController(IUserService userService,IConfiguration configuration,IMailService mail, AuthJwtToken authJwtToken)
    {
        _userService = userService;
        _configuration = configuration;
        _mail = mail;
        _authJwtToken = authJwtToken;
    }

    [HttpPost("createnew")]
    public async Task<ActionResult<ServiceResponse<AddUserDTO>>> CreateNewUser(AddUserDTO addUserDTO)
    {
        try
        {
            var newUser = _userService.CreateNewUser(addUserDTO);
            return Ok(new { message = "Create new user successfully", user = newUser });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Create user failed", err = ex.Message });
        }
    }
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ActionResult<ServiceResponse<GetUserDTO>>> UserLogin(LoginUserDTO loginUserDTO)
    {
        try
        {
            if (loginUserDTO.Email == null || loginUserDTO.UserPassword == null)
            {
                return BadRequest("Email or user password not valid");
            }
            
            return await _userService.UserLogin(loginUserDTO );
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Login user failed", err = ex.Message });
        }

    }

    [HttpPost("forgotpassword")]
    public async Task<ActionResult<ServiceResponse<GetUserDTO>>> SendMailAsync(MailData mailData)
    {
        var checkUserExist = await _userService.GetUserByEmail(mailData.To);
        if (checkUserExist.Success == false ) return NotFound("User email not found");
        mailData.Token = _authJwtToken.CreateToken(mailData.To);
        Console.WriteLine(mailData.Token);
        //var result = await _mail.SendAsync(mailData, new CancellationToken());
        var result = true;
        if(result)
        {
            return Ok("Send mail successfully");
        }
        else
        {
            return BadRequest("Send mail failed. Try again!");
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetUserDTO>>>> GetAllUser()
    {
        try
        {
           return await _userService.GetAllUser();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Get all user failed", err = ex.Message });
        }
    }

    [HttpPut("resetpassword/{token}")]
    public async Task<ActionResult<ServiceResponse<GetUserDTO>>> ResetPassword(string token,LoginUserDTO loginUserDTO)
    {
        try
        { 
            return await _userService.ResetPassword(token,loginUserDTO.UserPassword);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Get all user failed", err = ex.Message });
        }
    }
}