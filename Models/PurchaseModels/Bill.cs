using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSebda3.Models.PurchaseModels
{
    public class Bill
    {

        [Key]
        public int Id { get; set; }
        [ForeignKey("Vendor")]

        public int VendorId { get; set; }
       
        public double Total { get; set; }

        public DateTime BillDate { get; set; }



        public virtual Vendor Vendor { get; set; } = null!;
        public virtual List<Bill_Items> _Items { get; set; } = new List<Bill_Items>();
    }
}
