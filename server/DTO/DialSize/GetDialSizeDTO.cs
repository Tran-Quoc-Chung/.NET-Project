using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO.DialSize
{
    public class GetDialSizeDTO
    {
        [Required]
        public int DialSizeID { get; set; }
        
        [Required]
        public string DialSizeName { get; set; } = string.Empty;
    }
}
