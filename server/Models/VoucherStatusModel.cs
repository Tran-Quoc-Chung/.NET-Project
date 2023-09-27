using System;
using System.ComponentModel.DataAnnotations;
namespace server.Models
{
    public class VoucherStatus
    {
        public int VoucherStatusID { get; set; }
        [Required]
        public string VoucherStatusName { get; set; } = string.Empty;    
        }
}
