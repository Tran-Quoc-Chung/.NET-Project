using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO.VoucherStatus
{
    public class AddVoucherStatusDTO
    {
        public int VoucherStatusID { get; set; }
        [Required]
        public string VoucherStatusName { get; set; } = string.Empty;    
        }
}
