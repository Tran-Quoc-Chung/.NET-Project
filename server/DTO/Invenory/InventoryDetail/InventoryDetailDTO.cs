using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class InventoryDetailDTO{
        //public int InventoryID  { get; set; } 
        public int ProductID  { get; set; }
        public string? ProductName { get; set; } = string.Empty;
        public int Quantity  { get; set; }
        public List<string>? Images { get; set; } = new List<string>();
    }
    

}