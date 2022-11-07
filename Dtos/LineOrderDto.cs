using System;

namespace POSebda3.Dtos
{
    public class LineOrderDto
    {
        public int Id { get; set; }


        public int ProductId { get; set; }

        public int Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
