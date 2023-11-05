using System;
namespace server.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Sold { get; set; }
        public double TotalRating { get; set; }
        public Brand Brand { get; set; }
        public DialSize DialSize { get; set;}
        public StrapMaterial StrapMaterial { get; set;}
        public Tag Tag { get; set;}
        public WaterResistance WaterResistance { get; set;}
        public Gender Gender { get; set;}
        public DialShape DialShape { get; set;}
        public InvoiceDetail InvoiceDetail {get; set; }

        
    }
}
