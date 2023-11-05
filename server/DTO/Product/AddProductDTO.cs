using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class AddProductDTO{
        [Required]
        public int ProductID {get; set; }

        [Required]
        public string ProductName {get; set;} = string.Empty;

        public string Description {get; set; } = string.Empty;

        [Required]
        public float Price {get; set; }

        [Required]
        public int Quantity {get; set;}

        [Required]
        public int Sold {get; set;}

        [Required]
        public int TotalRating {get; set;}

        [Required]
        public int BrandID {get; set;}

        [Required]
        public int DiaSizeID {get; set;}

        [Required]
        public int StrapMaterialID {get; set;}

        [Required]
        public int TagID {get; set;}

        [Required]
        public int WaterResistanceID {get; set;}

        [Required]
        public int GenderID {get; set;}

        [Required]
        public int DiaShapeID {get; set;}

        [Required]
        public int InvoiceDetailID {get; set;}

    }
    

}