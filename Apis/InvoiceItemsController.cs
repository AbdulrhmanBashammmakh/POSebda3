using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSebda3.Data;
using POSebda3.Models.SalesModels;

namespace POSebda3.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InvoiceItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice_Items>>> GetInvoiceItems()
        {
            return await _context.InvoiceItems.ToListAsync();
        }

        // GET: api/InvoiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice_Items>> GetInvoice_Items(int id)
        {
            var invoice_Items = await _context.InvoiceItems.FindAsync(id);

            if (invoice_Items == null)
            {
                return NotFound();
            }

            return invoice_Items;
        }

        // PUT: api/InvoiceItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice_Items(int id, Invoice_Items invoice_Items)
        {
            if (id != invoice_Items.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice_Items).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Invoice_ItemsExists(id))
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

        // POST: api/InvoiceItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoice_Items>> PostInvoice_Items(Invoice_Items invoice_Items)
        {
            _context.InvoiceItems.Add(invoice_Items);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice_Items", new { id = invoice_Items.Id }, invoice_Items);
        }

        // DELETE: api/InvoiceItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice_Items(int id)
        {
            var invoice_Items = await _context.InvoiceItems.FindAsync(id);
            if (invoice_Items == null)
            {
                return NotFound();
            }

            _context.InvoiceItems.Remove(invoice_Items);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Invoice_ItemsExists(int id)
        {
            return _context.InvoiceItems.Any(e => e.Id == id);
        }
    }
}
