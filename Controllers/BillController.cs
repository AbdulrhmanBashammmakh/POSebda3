using Microsoft.AspNetCore.Mvc;
using POSebda3.Data;
using POSebda3.VMs;
using System.Linq;

namespace POSebda3.Controllers
{
    public class BillController : Controller

    {
        private readonly ApplicationDbContext _context;

        public BillController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(new PurchasesViewModels
            {
                CategoryList=_context.Categories.ToList(),
                VendorList=_context.Vendors.ToList()
            });
        }
    }
}
