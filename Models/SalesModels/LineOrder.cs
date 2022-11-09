
using POSebda3.Models.ProductModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSebda3.Models.SalesModels
{
    public class LineOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
