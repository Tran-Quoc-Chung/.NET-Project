using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class DialShapeDTO
    {
        public int? DialShapeID { get; set; }
        public string DialShapeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? CreatedBy { get; set; } = string.Empty;
        public string? CreatedAt { get; set; } = string.Empty;
    }
}
