using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSebda3.Data;
using POSebda3.Models.SalesModels;
using POSebda3.Dtos;
using AutoMapper;

namespace POSebda3.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceItemsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InvoiceItemsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/InvoiceItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice_ItemsDto>>> GetInvoiceItems()
        {
            var invoices = await _context.InvoiceItems.ToListAsync();
            var invoicesDto = _mapper.Map<List<Invoice_ItemsDto>>(invoices);
            return new JsonResult(invoicesDto);

            
        }

        // GET: api/InvoiceItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice_ItemsDto>> GetInvoice_Items(int id)
        {
            var invoice_Items = await _context.InvoiceItems.FindAsync(id);

            if (invoice_Items == null)
            {
                return NotFound();
            }
            var invoice_Itemsdto = _mapper.Map<Invoice_ItemsDto>(invoice_Items);
            return new JsonResult(invoice_Itemsdto);
         
        }

    

        // POST: api/InvoiceItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Invoice_ItemsDto>> PostInvoice_Items(Invoice_ItemsDto invoice_ItemsDto)
        {
            var invoice_Items= _mapper.Map<Invoice_Items>(invoice_ItemsDto);
            _context.InvoiceItems.Add(invoice_Items);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice_Items", new { id = invoice_ItemsDto.Id }, invoice_ItemsDto);
        }

     
    }
}
