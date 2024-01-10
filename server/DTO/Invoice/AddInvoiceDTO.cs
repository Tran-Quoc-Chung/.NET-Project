using System;
using System.ComponentModel.DataAnnotations;
namespace server.DTO
{
    public class AddInvoiceDTO
    {
        public List<InvoiceDetailDTO> ListProduct { get; set; } = new List<InvoiceDetailDTO>();
        public string? VoucherCode { get; set; }
        public int? TotalDiscount { get; set; }
        public int SubTotal { get; set; }
        public int TotalProduct { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? Note { get; set; }
        
    }
}
