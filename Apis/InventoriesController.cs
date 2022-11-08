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
using POSebda3.Models.ProductModels;

namespace POSebda3.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InventoriesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Inventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDto>>> GetInventories()
        {
            var inventory = await _context.Inventories.ToListAsync();
            var inventorydto = _mapper.Map<List<InventoryDto>>(inventory);

            return inventorydto;
        }

        // GET: api/Inventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryDto>> GetInventory(int id)
        {
            var inventory = await _context.Inventories.Where(x => x.ItemId == id).FirstOrDefaultAsync();

            if (inventory == null)
            {
                return NotFound();
            }

            var inventorydto =_mapper.Map<InventoryDto>(inventory);
            return new JsonResult(inventorydto);
        }

    }
}
