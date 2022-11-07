
using POSebda3.Models.ProductModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSebda3.Models.PurchaseModels
{
    public class Bill_Items
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Bill")]
        public int BillId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }

        public Bill Bill { get; set; }

        public Product Product { get; set; }= new Product();
    }
}
