using System;
namespace server.Models
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public Customer Customerid { get; set; }
        public User Userid { get; set; }
        public DateTime CreatedAt { get; set; }
        public int TotalProduct { get; set; }
        public float Discount { get; set; }
        public float Total { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Note { get; set; }
        public StatusInvoice StatusInvoice { get; set; }
        
    }
}
