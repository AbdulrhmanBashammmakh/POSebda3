using Microsoft.AspNetCore.Mvc;
using POSebda3.Data;
using POSebda3.VMs;
using System.Linq;

namespace POSebda3.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InvoiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(new SalesViewModels
            {
                CategoryList = _context.Categories.ToList()
            }) ;
        }
    }
}
