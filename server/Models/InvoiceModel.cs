using System;
namespace server.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public Customer CustomerId { get; set; }
        public User? UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalProduct { get; set; }
        public Voucher? Voucher { get; set; } = null!;
        public float TotalDiscount { get; set; }
        public float SubTotal { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? Note { get; set; }
        public SystemStatus StatusInvoice { get; set; }
        
    }
}
