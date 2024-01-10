using System;
namespace server.Models
{
    public class InvoiceDetail
    {
        public int InvoiceDetailID { get; set; }
        public Invoice Invoiceid { get; set; } = null!;
        public Product Productid { get; set; }= null!;
        public int Quantity { get; set; }
        public int SubTotal { get; set; }

    }
}
