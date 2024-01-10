using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using server.Models;


namespace server.DTO.Voucher
{
    public class UpdateVoucherDTO
    {
        [Unicode]
        [Key]
        public string VoucherCode { get; set; }
        [Required]
        public float Discount { get; set; }
        [Required]
        public UserToRole CreatedBy { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
