using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace server.Models
{
    public class CartDetail
    {
        public int CartDetailID { get; set; }
        [Required]
        public Cart Cartid { get; set; }
        [Required]
        public Product Productid { get; set; }
        public int Quantity { get; set; }
        
    }
}
