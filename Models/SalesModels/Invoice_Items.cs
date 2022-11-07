
using POSebda3.Models.ProductModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSebda3.Models.SalesModels
{
    public class Invoice_Items
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }

        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }

        public virtual Invoice Invoice { get; set; } = null!;
        public virtual Product Product { get; set; }=new Product();
    }
}
