using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSebda3.Data;
using POSebda3.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSebda3.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ValuesController(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper=    mapper;
        }

        [HttpGet("{id}")]
       
       public async Task<IActionResult> GetItems(int? id)
        {
            var listpro = await _context.Products.Where(x => x.CategoryId == id).ToListAsync();
            var listproDto = _mapper.Map<List<ProductDto>>(listpro);
            return new JsonResult(listproDto);
        }
    }
}