using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace server.Models
{
    public class Voucher
    {
        [Unicode]
        [Key]
        public string VoucherCode { get; set; }
        [Required]
        public float Discount { get; set; }
        [Required]
        public User CreatedBy { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public VoucherStatus VoucherStatus { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
