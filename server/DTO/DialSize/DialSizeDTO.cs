using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO.DialSize
{
    public class DialSizeDTO
    {
        public int DialSizeID { get; set; }
        public string DialSizeName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? CreatedBy { get; set; } = string.Empty;
        public string? CreatedAt { get; set; } = string.Empty;
    }
}
