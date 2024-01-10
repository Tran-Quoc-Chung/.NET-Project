using System;
namespace server.Models
{
    public class DialShape
    {
        public int DialShapeID { get; set; }
        public string DialShapeName { get; set; } = string.Empty;   
        public string? Description { get; set; } = string.Empty;

        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
