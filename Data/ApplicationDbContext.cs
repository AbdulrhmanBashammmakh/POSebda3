using Microsoft.EntityFrameworkCore;
using POSebda3.Models.ProductModels;
using POSebda3.Models.PurchaseModels;
using POSebda3.Models.SalesModels;

namespace POSebda3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<Category> Categories { get; set; } = null!;


        public virtual DbSet<Inventory> Inventories { get; set; } = null!;


        public virtual DbSet<Product> Products { get; set; } = null!;

        public virtual DbSet<Invoice_Items> InvoiceItems { get; set; } = null!;

        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Bill_Items> BillItems { get; set; } = null!;
        public virtual DbSet<LineOrder> LineOrders { get; set; } = null!;
        public virtual DbSet<Vendor> Vendors { get; set; } = null!;
        

    }
}
