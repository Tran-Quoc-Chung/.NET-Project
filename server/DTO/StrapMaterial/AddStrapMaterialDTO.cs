using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO.StrapMaterial
{
    public class AddStrapMaterialDTO
    {
        public int StrapMaterialID { get; set; }
        [Required]
        public string StrapMaterialName { get; set; } = string.Empty;
    }
}
