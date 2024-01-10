using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class ProductDTO{
        public int ProductID {get; set; }
        public string ProductName {get; set;} = string.Empty;
        public string Description {get; set; } = string.Empty;
        public int SellPrice {get; set; }
        public double TotalRating {get; set;}
        public string Brand {get; set;}
        public string DialSize {get; set;}
        public string StrapMaterial {get; set;}
        public string Tag {get; set;}
        public string WaterResistance {get; set;}
        public string Gender {get; set;}
        public string DialShape {get; set;}
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string Original { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int? Import_count { get; set; }
        public int? Sold_count { get; set; }

    }
}