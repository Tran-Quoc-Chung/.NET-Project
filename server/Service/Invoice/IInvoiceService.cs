using System;
using System.Collections.Generic;
using server.Controllers;
using server.DTO;
using server.DTO.Voucher;
using server.Models;


namespace server.Service{
    public interface IInvoiceService
    {
        // Task<ServiceResponse<GetVoucherDTO>> GetVoucherByCode(string code);
        
         Task<ServiceResponse<GetInvoiceDTO>> Create(AddInvoiceDTO addInvoiceDTO);
         Task<ServiceResponse<GetInvoiceDTO>> Update(string status, int id);
         Task<ServiceResponse<List<GetInvoiceDTO>>> GetAll(int id);
         Task<ServiceResponse<InvoiceDTO>> GetInvoiceById(int id);

    }
}