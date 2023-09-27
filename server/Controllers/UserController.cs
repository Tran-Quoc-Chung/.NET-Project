using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTO;
using server.DTO.User;
using server.Models;
using service.Service;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
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
    public async Task<ActionResult<ServiceResponse<LoginUserDTO>>> UserLogin(LoginUserDTO loginUserDTO)
    {
        try
        {
            if (loginUserDTO.UserName == null || loginUserDTO.UserPassword == null)
            {
                return BadRequest("Email or user password not valid");
            }
            Console.WriteLine("Test api");
            return Ok(await _userService.UserLogin(loginUserDTO));
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Login user failed", err = ex.Message });
        }

    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<GetUserDTO>>>> GetAllUser()
    {
        try
        {
            return Ok(await _userService.GetAllUser());
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = "Get all user failed", err = ex.Message });
        }
    }

}