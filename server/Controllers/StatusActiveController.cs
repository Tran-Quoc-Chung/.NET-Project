// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using server.Data;
// using server.DTO.StatusActive;
// using server.Models;
// using server.Service;

// namespace server.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class StatusActiveController : ControllerBase
// {
//     private readonly IStatusActiveService _statusActiveService;
//     public StatusActiveController(IStatusActiveService statusActiveService)
//     {
//         //_dataContext = dataContext;
//         _statusActiveService = statusActiveService;
//     }

//     [HttpGet]
//     public async Task<ActionResult<ServiceResponse<List<GetStatusActiveDTO>>>> GetAllStatusActive()
//     {
//         //ServiceResponse<List<>>
//         try{
//             return Ok(await _statusActiveService.GetAllStatusActive());
//         }catch(Exception ex){
//             return BadRequest(new { messenger = "Get all status active failed", err = ex.Message });
//         }
//     }

//     [HttpGet("{id}")]
//     public async Task<ActionResult<ServiceResponse<SystemStatus>>> GetSingle(int id)
//     {
//        try{
//         return Ok(await _statusActiveService.GetStatusActiveById(id));
//        }catch(Exception ex){
//             return BadRequest(new { message = "Get all status active faile", err = ex.Message });
//        }
//     }

//     [HttpPost("createnew")]
//     public async Task<ActionResult<ServiceResponse<List<AddStatusActiveDTO>>>> CreateNew(AddStatusActiveDTO addStatusActiveDTO)
//     {
//         try{
//             Console.WriteLine("Create new status active");
//             return Ok(await _statusActiveService.CreateNewStatusActive(addStatusActiveDTO));
//         }catch(Exception ex){
//             return BadRequest(new { message = "Create status active faile", err = ex.Message });
//         }
//     }

//     [HttpPut("update/{id}")]

//     public async Task<ActionResult<ServiceResponse<GetStatusActiveDTO>>> UpdateStatusActive(UpdateStatusActiveDTO updateStatusActiveDTO,int id)
//     {
//         if (id!=0){
//             updateStatusActiveDTO.StatusID = id;
//         }else{
//             return NotFound("Not found ID");
//         }
//         var response = await _statusActiveService.UpdateStatusActive(updateStatusActiveDTO);
//         if(response.Data == null || response.Success==false)
//         {
//             return NotFound(response);
//         }
//         return Ok(response);
//     }

//     [HttpDelete("delete/{id}")]
//     public async Task<ActionResult<ServiceResponse<GetStatusActiveDTO>>> DeleteStatusActive( int id)
//     {
//         var response = await _statusActiveService.DeleteStatusActive(id);
//         if(response.Data == null || response.Success==false)
//         {
//             return NotFound(response);
//         }
//         return Ok(new{message="Delete status active successfully",ListStatus=response});
//     }

// }