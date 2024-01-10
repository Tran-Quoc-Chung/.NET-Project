using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;
namespace server.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        [Required]
        public User User { get; set; }
        public string? Partner { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
        public string? Description { get; set; } = string.Empty;
        public int Total { get; set; }
        public Partner? PartnerID { get; set; }
        public DateTime CreatedAt { get; set; }
        
    }
}
