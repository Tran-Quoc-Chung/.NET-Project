using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class GetProductDTO{
        public int ProductID {get; set; }
        public string ProductName {get; set;} = string.Empty;
        public string Description {get; set; } = string.Empty;
        public int SellPrice {get; set; }
        public int OriginPrice {get; set; }
        public int Quantity {get; set;}
        public int Sold {get; set;}
        public double TotalRating {get; set;}
        public int BrandID {get; set;}
        public int DialSizeID {get; set;}
        public int StrapMaterialID {get; set;}
        public int TagID {get; set;}
        public int WaterResistanceID {get; set;}
        public int GenderID {get; set;}
        public int DialShapeID {get; set;}
        public string CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public string Original { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public int StatusID { get; set; }
        public int? Import_count { get; set; }
        public int? Sold_count { get; set; }

    }
}