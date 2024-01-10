using System;
namespace server.Models
{
    public class DialSize
    {
        public int DialSizeID { get; set; }
        public string DialSizeName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
