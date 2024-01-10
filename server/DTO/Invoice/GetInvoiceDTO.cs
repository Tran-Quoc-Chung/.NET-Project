using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class GetInvoiceDTO
    {

        public int InvoiceID { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string CreateAt { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }= string.Empty;
        public string StatusInvoice { get; set; }= string.Empty;
        public string? UserName { get; set; }
        public float SubTotal { get; set; }

    }
}
