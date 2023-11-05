using System;
using System.ComponentModel.DataAnnotations;
using server.Models;

namespace server.DTO;

public class AddBrandDTO{

        [Required]
        public int BrandID { get; set; }
        [Required]
        public string BrandName { get; set; } = string.Empty;
        [Required]
        public Original Original { get; set; }
}