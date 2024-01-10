using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class WaterResistanceDTO
    {
        public int? WaterResistanceID { get; set; }
        public string WaterResistanceName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? CreatedBy { get; set; } = string.Empty;
        public string? CreatedAt { get; set; } = string.Empty;
    }
}
