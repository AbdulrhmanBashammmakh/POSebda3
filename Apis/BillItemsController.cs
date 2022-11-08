using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSebda3.Data;
using POSebda3.Models.PurchaseModels;
using POSebda3.Dtos;
using AutoMapper;

namespace POSebda3.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BillItemsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/BillItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill_ItemsDto>>> GetBillItems()
        {
            var bills = await _context.BillItems.ToListAsync();
            var billsdto = _mapper.Map<List<Bill_ItemsDto>>(bills);
            return new JsonResult(billsdto);
            
        }

        // GET: api/BillItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill_ItemsDto>> GetBill_Items(int id)
        {
            var bill_Items = await _context.BillItems.FindAsync(id);

            if (bill_Items == null)
            {
                return NotFound();
            }

            var bill_Itemsdto = _mapper.Map<Bill_ItemsDto>(bill_Items);
            return new JsonResult(bill_Itemsdto);
        }

      

        // POST: api/BillItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bill_ItemsDto>> PostBill_Items(Bill_ItemsDto bill_ItemsDto)
        {

            var bill_Items = _mapper.Map<Bill_Items>(bill_ItemsDto);
            _context.BillItems.Add(bill_Items);
            await _context.SaveChangesAsync();
            return Ok("done");
          
        }

       
    }
}
