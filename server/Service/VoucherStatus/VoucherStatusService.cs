using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO.VoucherStatus;
using server.Models;


namespace server.Service;

public class VoucherStatusService : IVoucherStatusService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public VoucherStatusService(IMapper mapper, DataContext dataContext)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<GetVoucherStatusDTO>> GetVoucherStatusById(int id)
    {
        
        var serviceResponse = new ServiceResponse<GetVoucherStatusDTO>();
        var dbVoucherStatus = await _dataContext.VoucherStatuss.FirstOrDefaultAsync(x => x.VoucherStatusID == id);
        var result = new GetVoucherStatusDTO
        {
            VoucherStatusID = dbVoucherStatus.VoucherStatusID,
            VoucherStatusName = dbVoucherStatus.VoucherStatusName
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetVoucherStatusDTO>>> GetAllVoucherStatus()
    {
        var serviceResponse = new ServiceResponse<List<GetVoucherStatusDTO>>();
        var dbVoucherStatus = await _dataContext.VoucherStatuss.ToListAsync();
        var result = dbVoucherStatus.Select(x => new GetVoucherStatusDTO
        {
            VoucherStatusID = x.VoucherStatusID,
            VoucherStatusName = x.VoucherStatusName
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetVoucherStatusDTO>>> CreateNewVoucherStatus(AddVoucherStatusDTO addVoucherStatusDTO)
    {
        var serviceResponse = new ServiceResponse<List<GetVoucherStatusDTO>>();
        var voucherStatus = _mapper.Map<VoucherStatus>(addVoucherStatusDTO);
        _dataContext.VoucherStatuss.Add(voucherStatus);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await _dataContext.VoucherStatuss.Select(x => _mapper.Map<GetVoucherStatusDTO>(x)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetVoucherStatusDTO>> UpdateVoucherStatus(UpdateVoucherStatusDTO updateVoucherStatusDTO)
    {
        var serviceResponse = new ServiceResponse<GetVoucherStatusDTO>();
        try{
              var VoucherStatus = await _dataContext.VoucherStatuss.FirstOrDefaultAsync(c => c.VoucherStatusID == updateVoucherStatusDTO.VoucherStatusID);
            if (VoucherStatus is null)
                throw new Exception("Update voucher status false");
        
        VoucherStatus.VoucherStatusName = updateVoucherStatusDTO.VoucherStatusName;
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetVoucherStatusDTO>(VoucherStatus);
        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
      
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetVoucherStatusDTO>>> DeleteVoucherStatus(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetVoucherStatusDTO>>();
        try{
            var VoucherStatus = await _dataContext.VoucherStatuss.FirstOrDefaultAsync(c => c.VoucherStatusID == id);
            if(VoucherStatus is null)
                throw new Exception("ID voucher status not found");
            _dataContext.VoucherStatuss.Remove(VoucherStatus);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.VoucherStatuss.Select(x => _mapper.Map<GetVoucherStatusDTO>(x)).ToListAsync();

        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }

    public Task<ServiceResponse<GetVoucherStatusDTO>> GetVoucherById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<GetVoucherStatusDTO>>> GetAllVoucher()
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<GetVoucherStatusDTO>>> CreateNewVoucher(AddVoucherStatusDTO addVoucherDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<GetVoucherStatusDTO>> UpdateVoucher(UpdateVoucherStatusDTO updateVoucherDTO)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<List<GetVoucherStatusDTO>>> DeleteVoucher(int id)
    {
        throw new NotImplementedException();
    }
}