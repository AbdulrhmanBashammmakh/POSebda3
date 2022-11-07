using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POSebda3.Models.SalesModels
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        public double Total { get; set; }
        public string CustomerName { get; set; } = null;
        public DateTime invoiceDate { get; set; }



        public virtual List<Invoice_Items> _Items{ get; set; }= new List<Invoice_Items>();
    
            
    }
}
