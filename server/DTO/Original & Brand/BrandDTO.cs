using System;
using System.ComponentModel.DataAnnotations;
using server.Models;

namespace server.DTO;

public class BrandDTO{

        public int BrandID { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string? CreatedBy { get; set; } = string.Empty;
        public string? CreatedAt { get; set; } = string.Empty;
}