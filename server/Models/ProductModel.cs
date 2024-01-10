using System;
namespace server.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public int OriginPrice { get; set; }
        public int SellPrice { get; set; }
        public double TotalRating { get; set; }
        public List<Images> Images { get; set; }= null!;
        public Brand Brand { get; set; }= null!;
        public DialSize DialSize { get; set;}= null!;
        public StrapMaterial StrapMaterial { get; set;}= null!;
        public Tag Tag { get; set;}= null!;
        public WaterResistance WaterResistance { get; set;}= null!;
        public Gender Gender { get; set;}= null!;
        public DialShape DialShape { get; set;}= null!;
        public User CreatedBy { get; set; }= null!;
        public DateTime CreatedAt { get; set; }
        public SystemStatus StatusActive { get; set; }= null!;
        public string? Color { get; set; } = string.Empty;
        public int? import_count { get; set; }
        public int? sold_count { get; set; }
        
        
    }
}
