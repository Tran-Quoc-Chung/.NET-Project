using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO.Voucher;
using server.Models;


namespace server.Service{
    public interface IVoucherService
    {
        Task<ServiceResponse<GetVoucherDTO>> GetVoucherByCode(string code);
        Task<ServiceResponse<List<GetVoucherDTO>>> GetAllVoucher();
        Task<ServiceResponse<GetVoucherDTO>> Create(AddVoucherDTO addVoucherDTO);
        Task<ServiceResponse<GetVoucherDTO>> UpdateVoucher(AddVoucherDTO addVoucherDTO);
        Task<ServiceResponse<GetVoucherDTO>> DeleteVoucher(string code);
    }
}