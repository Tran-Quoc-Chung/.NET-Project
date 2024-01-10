using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class UpdateStrapMaterialDTO
    {
        public int StrapMaterialID { get; set; }
        [Required]
        public string StrapMaterialName { get; set; } = string.Empty;
    }
}
