using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO.VoucherStatus;
using server.Models;


namespace server.Service{
    public interface IVoucherStatusService
    {
        Task<ServiceResponse<GetVoucherStatusDTO>> GetVoucherById(int id);
        Task<ServiceResponse<List<GetVoucherStatusDTO>>> GetAllVoucher();
        Task<ServiceResponse<List<GetVoucherStatusDTO>>> CreateNewVoucher(AddVoucherStatusDTO addVoucherDTO);
        Task<ServiceResponse<GetVoucherStatusDTO>> UpdateVoucher(UpdateVoucherStatusDTO updateVoucherDTO);
        Task<ServiceResponse<List<GetVoucherStatusDTO>>> DeleteVoucher(int id);
    }
}