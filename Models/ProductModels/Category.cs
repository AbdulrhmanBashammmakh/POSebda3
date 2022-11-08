using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSebda3.Models.ProductModels
{
    public class Category
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string CategoryName { get; set; }

      //  public virtual ICollection<Product> products { get; set; }
    }
}
