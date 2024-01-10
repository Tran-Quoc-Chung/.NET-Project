// using AutoMapper;
// using Microsoft.AspNetCore.Http.HttpResults;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.VisualBasic;
// using server.Data;
// using server.DTO.StatusActive;
// using server.Models;

// namespace server.Service;

// public class StatusActiveService : IStatusActiveService
// {
//     private readonly DataContext _dataContext;
//     private readonly IMapper _mapper;
//     public StatusActiveService(IMapper mapper, DataContext dataContext)
//     {
//         _dataContext = dataContext;
//         _mapper = mapper;
//     }
//     public async Task<ServiceResponse<GetStatusActiveDTO>> GetStatusActiveById(int id)
//     {
        
//         var serviceResponse = new ServiceResponse<GetStatusActiveDTO>();
//         var dbStatusActive = await _dataContext.StatusActives.FirstOrDefaultAsync(x => x.StatusID == id);
//         var result = new GetStatusActiveDTO
//         {
//             StatusID = dbStatusActive.StatusID,
//             StatusName = dbStatusActive.StatusName
//         };
//         serviceResponse.Data = result;
//         return serviceResponse;
//     }
//     public async Task<ServiceResponse<List<GetStatusActiveDTO>>> GetAllStatusActive()
//     {
//         var serviceResponse = new ServiceResponse<List<GetStatusActiveDTO>>();
//         var dbStatusActive = await _dataContext.StatusActives.ToListAsync();
//         var result = dbStatusActive.Select(x => new GetStatusActiveDTO
//         {
//             StatusID = x.StatusID,
//             StatusName = x.StatusName
//         }).ToList();
//         serviceResponse.Data = result;
//         return serviceResponse;
//     }

//     public async Task<ServiceResponse<List<GetStatusActiveDTO>>> CreateNewStatusActive(AddStatusActiveDTO addStatusActiveDTO)
//     {
//         var serviceResponse = new ServiceResponse<List<GetStatusActiveDTO>>();
//         var statusActive = _mapper.Map<StatusActive>(addStatusActiveDTO);
//         _dataContext.StatusActives.Add(statusActive);
//         await _dataContext.SaveChangesAsync();
//         serviceResponse.Data = await _dataContext.StatusActives.Select(x => _mapper.Map<GetStatusActiveDTO>(x)).ToListAsync();
//         return serviceResponse;
//     }

//     public async Task<ServiceResponse<GetStatusActiveDTO>> UpdateStatusActive(UpdateStatusActiveDTO updateStatusActiveDTO)
//     {
//         var serviceResponse = new ServiceResponse<GetStatusActiveDTO>();
//         try{
//               var statusActive = await _dataContext.StatusActives.FirstOrDefaultAsync(c => c.StatusID == updateStatusActiveDTO.StatusID);
//             if (statusActive is null)
//                 throw new Exception("Update status active false");
        
//         statusActive.StatusName = updateStatusActiveDTO.StatusName;
//         await _dataContext.SaveChangesAsync();
//         serviceResponse.Data = _mapper.Map<GetStatusActiveDTO>(statusActive);
//         }catch{
//             serviceResponse.Success = false;
//             serviceResponse.Message = "Update failed";
//         }
      
//         return serviceResponse;
//     }

//     public async Task<ServiceResponse<List<GetStatusActiveDTO>>> DeleteStatusActive(int id)
//     {
//         var serviceResponse = new ServiceResponse<List<GetStatusActiveDTO>>();
//         try{
//             var statusActive = await _dataContext.StatusActives.FirstOrDefaultAsync(c => c.StatusID == id);
//             if(statusActive is null)
//                 throw new Exception("ID status active not found");
//             _dataContext.StatusActives.Remove(statusActive);
//             await _dataContext.SaveChangesAsync();
//             serviceResponse.Data = await _dataContext.StatusActives.Select(x => _mapper.Map<GetStatusActiveDTO>(x)).ToListAsync();

//         }catch{
//             serviceResponse.Success = false;
//             serviceResponse.Message = "Update failed";
//         }
//         return serviceResponse;
//     }
// }