using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class AddInventoryDTO{
        public int Partner { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int? Price  { get; set; } 
        public int? Discount  { get; set; } 
        public int? Total  { get; set; }
        public List<InventoryDetailDTO> InventoryDetail { get; set; } = new List<InventoryDetailDTO>();
    }
    

}