using System;
namespace server.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailID { get; set; }
        public Invoice Invoiceid { get; set; }
        public List<Product> Products { get; set; }
        
    }
}
