using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class GetInventoryDTO{
        public int InventoryID { get; set; }
        public int UserID { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string? CreatedAt { get; set; } = string.Empty;
        public string Partner { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? Quantity  { get; set; } 
        public int? Price  { get; set; } 
        public int? Discount  { get; set; } 
        public int? Total  { get; set; }
        public List<InventoryDetailDTO>? InventoryDetail { get; set; } = null!;
    }
    

}