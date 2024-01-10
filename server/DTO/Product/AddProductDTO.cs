using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class AddProductDTO{
        [Required]
        public int ProductID {get; set; }

        public string ProductName {get; set;} = string.Empty;

        public string Description {get; set; } = string.Empty;

        public int OriginPrice { get; set; }
        public int SellPrice { get; set; }
        public int TotalRating {get; set;}

        public int BrandID {get; set;}

        public int DialSizeID {get; set;}

        public int StrapMaterialID {get; set;}
        public int TagID {get; set;}

        public int WaterResistanceID {get; set;}

        public int GenderID {get; set;}

        public int DialShapeID {get; set;}
        public string Color { get; set; } = string.Empty;
        public int StatusID { get; set; }
        public List<ImagesDTO>? ProductImage { get; set; }
        public int? import_count { get; set; }
        public int? sold_count { get; set; }
    }
    

}