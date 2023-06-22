using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EvilInsultAPI.Models;
using EvilInsultAPI.Models.Domain;
using EvilInsultAPI.Services.InsultService;
using AutoMapper;
using EvilInsultAPI.Models.DTOs.InsultDTOs;

namespace EvilInsultAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsultsController : ControllerBase
    {
        private readonly EvilDbContext _context;
        private readonly IInsultService _insultService;
        private readonly IMapper _mapper;

        public InsultsController(EvilDbContext context, IInsultService insultService, IMapper mapper)
        {
            _context = context;
            _insultService = insultService;
            _mapper = mapper;

        }

        // GET: api/Insults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsultGeneralDTO>>> GetInsults()
        {
            return Ok(_mapper.Map<List<InsultGeneralDTO>>(await _insultService.GetAllAsync()));
        }

        // GET: api/Insults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insult>> GetInsult(int id)
        {
          if (_context.Insults == null)
          {
              return NotFound();
          }
            var insult = await _context.Insults.FindAsync(id);

            if (insult == null)
            {
                return NotFound();
            }

            return insult;
        }

        // PUT: api/Insults/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsult(int id, Insult insult)
        {
            if (id != insult.Id)
            {
                return BadRequest();
            }

            _context.Entry(insult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsultExists(id))
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

        // POST: api/Insults
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Insult>> PostInsult(Insult insult)
        {
          if (_context.Insults == null)
          {
              return Problem("Entity set 'EvilDbContext.Insults'  is null.");
          }
            _context.Insults.Add(insult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsult", new { id = insult.Id }, insult);
        }

        // DELETE: api/Insults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsult(int id)
        {
            if (_context.Insults == null)
            {
                return NotFound();
            }
            var insult = await _context.Insults.FindAsync(id);
            if (insult == null)
            {
                return NotFound();
            }

            _context.Insults.Remove(insult);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsultExists(int id)
        {
            return (_context.Insults?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
