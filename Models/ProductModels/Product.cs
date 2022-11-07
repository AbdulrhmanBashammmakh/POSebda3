using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSebda3.Models.ProductModels
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public string Code { get; set; } = null;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

      

        public virtual Category Category { get; set; } = null;
        public virtual ICollection<Inventory> inventory { get; set; }
    }
}
