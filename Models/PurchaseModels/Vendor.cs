using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSebda3.Models.PurchaseModels
{
    public class Vendor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string Phone { get; set; } = null!;

       
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
