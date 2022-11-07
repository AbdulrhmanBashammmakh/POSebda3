using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POSebda3.Models.ProductModels
{
    public class Inventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ItemId { get; set; }
        public string Detials { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int AvaQuantity { get; set; } = 0;

        [Range(0, double.MaxValue)]
        public double SellingPrice { get; set; } = 0;

        [Range(0, double.MaxValue)]
        public double CostPrice { get; set; } = 0;

        public virtual Product product { get; set; } = null;
    }
}
