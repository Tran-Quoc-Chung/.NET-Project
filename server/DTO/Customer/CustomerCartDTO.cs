using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace server.DTO
{
    public class CustomerCartDTO
    {
        public int CartId { get; set; }
        public int CustomerId { get; set; }
        public string TotalCart { get; set; } = string.Empty;
        public List<CartDetailDTO> ListProduct { get; set; } = new List<CartDetailDTO>();
    }
}
