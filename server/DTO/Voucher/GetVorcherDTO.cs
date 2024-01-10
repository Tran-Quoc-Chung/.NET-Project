using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.DTO.Voucher
{
    public class GetVoucherDTO
    {
        public string VoucherCode { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int QuantityRemain { get; set; }
        public string VoucherStatusName { get; set; }= string.Empty;
        public float Discount { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
         
    }
}
