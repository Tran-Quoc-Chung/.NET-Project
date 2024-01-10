using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.DTO.Voucher
{
    public class AddVoucherDTO
    {
        [Unicode]
        [Key]
        public string VoucherCode { get; set; }
        public string EventName { get; set; } = string.Empty;
        public float Discount { get; set; }
        public int Quantity { get; set; }
        public int QuantityRemain { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
         
    }
}
