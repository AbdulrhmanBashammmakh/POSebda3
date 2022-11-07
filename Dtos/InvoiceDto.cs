using System;

namespace POSebda3.Dtos
{
    public class InvoiceDto
    {
        public int Id { get; set; }

        public double Total { get; set; }
        public string CustomerName { get; set; } = null;
        public DateTime invoiceDate { get; set; }
    }
}
