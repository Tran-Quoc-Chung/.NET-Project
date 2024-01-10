using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace server.DTO
{
    public class CartDetailDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; } = string.Empty;
        public int? Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public int? Quantity { get; set; }
    }
}
