using System;
namespace server.Models
{
    public class WaterResistance
    {
        public int WaterResistanceID { get; set; }
        public string WaterResistanceName { get; set; } = string.Empty;  
        public string? Description { get; set; } = string.Empty;
 
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        }
}
