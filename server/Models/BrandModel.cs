using System;
using System.ComponentModel.DataAnnotations;
namespace server.Models
{
    public class Brand
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string Original { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public User CreatedBy { get; set; }= null!;
        public DateTime CreatedAt { get; set; }
    }
}
