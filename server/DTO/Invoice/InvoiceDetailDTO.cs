using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class InvoiceDetailDTO
    {
        public int ProductID { get; set; }
        public int InvoiceID { get; set; }
        public int Quantity { get; set; }
        public int SubTotal { get; set; }
        public string? URLImage { get; set; } = string.Empty;
        public string? ProductName { get; set; } = string.Empty;
        public int? Price { get; set; } 
        
    }
}
