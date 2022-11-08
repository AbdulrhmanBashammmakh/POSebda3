using System;
using POSebda3.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSebda3.Data;
using POSebda3.Models.PurchaseModels;

namespace POSebda3.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BillsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Bills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillDto>>> GetBills()
        {

            var bills = await _context.Bills.ToListAsync();
            var billsdto = _mapper.Map<List<BillDto>>(bills);
            return new JsonResult(billsdto);
            
        }

        // GET: api/Bills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillDto>> GetBill(int id)
        {
            var bill = await _context.Bills.FindAsync(id);

            if (bill == null)
            {
                return NotFound();
            }
            var billdto = _mapper.Map<BillDto>(bill);
            return new JsonResult(billdto);
        }

       

        // POST: api/Bills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillDto>> PostBill(BillDto billDto)
        {
            var bill = _mapper.Map<Bill>(billDto);
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBill", new { id = billDto.Id }, billDto);
        }

       
    }
}
