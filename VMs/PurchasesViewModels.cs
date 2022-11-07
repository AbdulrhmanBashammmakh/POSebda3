using POSebda3.Models.ProductModels;
using POSebda3.Models.PurchaseModels;
using System.Collections.Generic;

namespace POSebda3.VMs
{
    public class PurchasesViewModels
    {
        public List<Category> CategoryList { get; set; } = new List<Category>();
        public List<Vendor> VendorList { get; set; } = new List<Vendor>();
    }
}
