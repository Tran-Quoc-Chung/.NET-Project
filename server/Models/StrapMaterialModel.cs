using System;
using System.ComponentModel.DataAnnotations;
namespace server.Models
{
    public class StrapMaterial
    {
        public int StrapMaterialID { get; set; }
        [Required]
        public string StrapMaterialName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
