using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace server.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        [Required]
        public Customer Customerid { get; set; }
        [Required]
        public int TotalCart { get; set; }
    }
}
