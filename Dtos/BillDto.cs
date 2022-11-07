using System;

namespace POSebda3.Dtos
{
    public class BillDto
    {

        public int Id { get; set; }
    

        public int VendorId { get; set; }

        public double Total { get; set; }

        public DateTime BillDate { get; set; }
    }
}
