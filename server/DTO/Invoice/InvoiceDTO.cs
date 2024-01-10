using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class InvoiceDTO
    {

        public int InvoiceID { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string CreateAt { get; set; }
        public int Quantity { get; set; }
        public string Note { get; set; }= string.Empty;
        public int StatusInvoice { get; set; }
        public string? UserName { get; set; }
        public string? VoucherCode { get; set; } = string.Empty;
        public float? TotalDiscount { get; set; }
        public string Location { get; set; } = string.Empty;
        public float Subtotal { get; set; }

        public List<InvoiceDetailDTO> InvoiceDetail { get; set; } = new List<InvoiceDetailDTO>();
        


    }
}
