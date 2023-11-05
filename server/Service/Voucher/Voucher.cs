using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using server.Data;
using server.DTO.Voucher;
using server.Models;

namespace server.Service;

public class VoucherService : IVoucherService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public VoucherService(IMapper mapper, DataContext dataContext)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<GetVoucherDTO>> GetVoucherByCode(string code)
    {
        
        var serviceResponse = new ServiceResponse<GetVoucherDTO>();
        var dbVoucher = await _dataContext.Vouchers.FirstOrDefaultAsync(x => x.VoucherCode == code);
        var result = new GetVoucherDTO
        {
            VoucherCode = dbVoucher.VoucherCode,
            
        };
        serviceResponse.Data = result;
        return serviceResponse;
    }
    public async Task<ServiceResponse<List<GetVoucherDTO>>> GetAllVoucher()
    {
        var serviceResponse = new ServiceResponse<List<GetVoucherDTO>>();
        var dbVoucher = await _dataContext.Vouchers.ToListAsync();
        var result = dbVoucher.Select(x => new GetVoucherDTO
        {
            VoucherCode = x.VoucherCode,
           
        }).ToList();
        serviceResponse.Data = result;
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetVoucherDTO>>> CreateNewVoucher(AddVoucherDTO addVoucherDTO)
    {
        var serviceResponse = new ServiceResponse<List<GetVoucherDTO>>();
        var Voucher = _mapper.Map<Voucher>(addVoucherDTO);
        _dataContext.Vouchers.Add(Voucher);
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = await _dataContext.Vouchers.Select(x => _mapper.Map<GetVoucherDTO>(x)).ToListAsync();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetVoucherDTO>> UpdateVoucher(UpdateVoucherDTO updateVoucherDTO)
    {
        var serviceResponse = new ServiceResponse<GetVoucherDTO>();
        try{
              var Voucher = await _dataContext.Vouchers.FirstOrDefaultAsync(c => c.VoucherCode == updateVoucherDTO.VoucherCode);
            if (Voucher is null)
                throw new Exception("Update Voucher false");
        
        Voucher.Discount = updateVoucherDTO.Discount;
        
        await _dataContext.SaveChangesAsync();
        serviceResponse.Data = _mapper.Map<GetVoucherDTO>(Voucher);
        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
      
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetVoucherDTO>>> DeleteVoucher(string code)
    {
        var serviceResponse = new ServiceResponse<List<GetVoucherDTO>>();
        try{
            var Voucher = await _dataContext.Vouchers.FirstOrDefaultAsync(c => c.VoucherCode == code);
            if(Voucher is null)
                throw new Exception("Code voucher not found");
            _dataContext.Vouchers.Remove(Voucher);
            await _dataContext.SaveChangesAsync();
            serviceResponse.Data = await _dataContext.Vouchers.Select(x => _mapper.Map<GetVoucherDTO>(x)).ToListAsync();

        }catch{
            serviceResponse.Success = false;
            serviceResponse.Message = "Update failed";
        }
        return serviceResponse;
    }

    
}