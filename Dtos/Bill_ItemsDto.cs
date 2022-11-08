namespace POSebda3.Dtos
{
    public class Bill_ItemsDto
    {
        public int Id { get; set; } 


        public int BillId { get; set; }


        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
    }
}
