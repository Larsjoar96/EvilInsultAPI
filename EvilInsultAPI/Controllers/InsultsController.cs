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
using EvilInsultAPI.Utils;
using System.Net;

namespace EvilInsultAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsultsController : ControllerBase
    {
        private readonly IInsultService _insultService;
        private readonly IMapper _mapper;

        public InsultsController(EvilDbContext context, IInsultService insultService, IMapper mapper)
        {
            _insultService = insultService;
            _mapper = mapper;

        }

        // GET: api/Insults
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InsultGeneralDTO>>> GetInsults()
        {
            return Ok(_mapper.Map<List<InsultGeneralDTO>>(await _insultService.GetAllAsync()));
        }
        //GET: api/Insults/Language
        [HttpGet("language")]
        public async Task<ActionResult<IEnumerable<InsultGeneralDTO>>> GetInsultsInLanguage(string language) 
        {
            return Ok(_mapper.Map<List<InsultGeneralDTO>>(await _insultService.GetAllInsultsInLanguageAsync(language)));
        }

        // GET: api/Insults/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsultGeneralDTO>> GetInsult(int id)
        {
            try
            {
                return Ok(_mapper.Map<InsultGeneralDTO>(await _insultService.GetByIdAsync(id)));
            }
            catch (EntityNotFoundExeption ex)
            {
                return NotFound(
                    new ProblemDetails(){ Detail = ex.Message, Status = ((int)HttpStatusCode.NotFound) });
            }
        }

        // PUT: api/Insults/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsult(int id, InsultPutDTO insult)
        {
            if (id != insult.Id)
            {
                return BadRequest("Insult with that Id does not exist");
            }
            try
            {
                await _insultService.UpdateAsync(_mapper.Map<Insult>(insult));
                return NoContent();
            }
            catch (EntityNotFoundExeption ex)
            {
                return NotFound(new ProblemDetails() { Detail = ex.Message, Status = ((int)HttpStatusCode.NotFound) });
            }
        }

        // POST: api/Insults
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Insult>> PostInsult(InsultPostDTO insultDTO)
        {
            Insult insult = _mapper.Map<Insult>(insultDTO);
            await _insultService.AddAsync(insult);
            return CreatedAtAction("GetInsult", new { id = insult.Id }, insult);
        }

        // DELETE: api/Insults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsult(int id)
        {
            try
            {
                await _insultService.DeleteByIdAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundExeption ex)
            {
                return NotFound(new ProblemDetails() { Detail = ex.Message, Status = ((int)HttpStatusCode.NotFound) });
            }
        }
    }
}
