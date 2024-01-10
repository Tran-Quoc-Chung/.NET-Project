using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class GetStrapMaterialDTO
    {
        public int? StrapMaterialID { get; set; }
        public string StrapMaterialName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? CreatedBy { get; set; } = string.Empty;
        public string? CreatedAt { get; set; } = string.Empty;
    }
}
