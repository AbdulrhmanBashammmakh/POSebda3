using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSebda3.Data;
using POSebda3.Models.PurchaseModels;

namespace POSebda3.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BillItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BillItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill_Items>>> GetBillItems()
        {
            return await _context.BillItems.ToListAsync();
        }

        // GET: api/BillItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bill_Items>> GetBill_Items(int id)
        {
            var bill_Items = await _context.BillItems.FindAsync(id);

            if (bill_Items == null)
            {
                return NotFound();
            }

            return bill_Items;
        }

        // PUT: api/BillItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBill_Items(int id, Bill_Items bill_Items)
        {
            if (id != bill_Items.Id)
            {
                return BadRequest();
            }

            _context.Entry(bill_Items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Bill_ItemsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BillItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bill_Items>> PostBill_Items(Bill_Items bill_Items)
        {
            _context.BillItems.Add(bill_Items);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBill_Items", new { id = bill_Items.Id }, bill_Items);
        }

        // DELETE: api/BillItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBill_Items(int id)
        {
            var bill_Items = await _context.BillItems.FindAsync(id);
            if (bill_Items == null)
            {
                return NotFound();
            }

            _context.BillItems.Remove(bill_Items);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Bill_ItemsExists(int id)
        {
            return _context.BillItems.Any(e => e.Id == id);
        }
    }
}
