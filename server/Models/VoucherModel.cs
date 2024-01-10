using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using server.Models;
namespace server.Models
{
    public class Voucher
    {
        [Unicode]
        [Key]
        public string VoucherCode { get; set; }
        public string EventName { get; set; } = string.Empty;
        public float Discount { get; set; }
        public int Quantity { get; set; }
        public int QuantityRemain { get; set; }
        public string? Description { get; set; }
        public SystemStatus VoucherStatus { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public User CreatedBy { get; set; }= null!;
        public DateTime CreatedAt { get; set; }
    }
}
