using System;
using System.ComponentModel.DataAnnotations;
namespace server.Models
{
    public class StrapMaterial
    {
        public int StrapMaterialID { get; set; }
        [Required]
        public string StrapMaterialName { get; set; } = string.Empty;
    }
}
