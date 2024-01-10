using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Schema;
namespace server.Models
{
    public class InventoryDetail
    {
        public int ID { get; set; }
        public Inventory InventoryId { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        
    }
}
