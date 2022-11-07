namespace POSebda3.Dtos
{
    public class InventoryDto
    {
        public int Id { get; set; }

        public int ItemId { get; set; }
        public string Detials { get; set; } = string.Empty;

     
        public int AvaQuantity { get; set; } = 0;

       
        public double SellingPrice { get; set; } = 0;

  
        public double CostPrice { get; set; } = 0;
    }
}
