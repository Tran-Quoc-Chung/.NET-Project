using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class GetAllInventoryDTO{
        public int InventoryID { get; set; }
        public string UserName { get; set; }
        public string Partner { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int? Price  { get; set; } 
        public int? Discount  { get; set; } 
        public int? Total  { get; set; }
        public string? CreatedAt { get; set; } = string.Empty;
    }
    

}