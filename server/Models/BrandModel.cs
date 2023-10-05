using System;
using System.ComponentModel.DataAnnotations;
namespace server.Models
{
    public class Brand
    {
        public int BrandID { get; set; }
        [Required]
        public string BrandName { get; set; } = string.Empty;
        [Required]
        public Original Original { get; set; }
    }
}
