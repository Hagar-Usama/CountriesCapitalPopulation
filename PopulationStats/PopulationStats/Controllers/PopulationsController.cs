using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PopulationStats.Models;

namespace PopulationStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulationsController : ControllerBase
    {
        private readonly PopuContext _context;

        public PopulationsController(PopuContext context)
        {
            _context = context;
        }

        // GET: api/Populations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Population>>> GetPopulations()
        {
          if (_context.Populations == null)
          {
              return NotFound();
          }
            return await _context.Populations.ToListAsync();
        }

        // GET: api/Populations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Population>> GetPopulation(int id)
        {
          if (_context.Populations == null)
          {
              return NotFound();
          }
            var population = await _context.Populations.FindAsync(id);

            if (population == null)
            {
                return NotFound();
            }

            return population;
        }

        // PUT: api/Populations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPopulation(int id, Population population)
        {
            if (id != population.CityId)
            {
                return BadRequest();
            }

            _context.Entry(population).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PopulationExists(id))
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

        // POST: api/Populations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Population>> PostPopulation(Population population)
        {
          if (_context.Populations == null)
          {
              return Problem("Entity set 'PopuContext.Populations'  is null.");
          }
            _context.Populations.Add(population);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PopulationExists(population.CityId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPopulation", new { id = population.CityId }, population);
        }

        // DELETE: api/Populations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopulation(int id)
        {
            if (_context.Populations == null)
            {
                return NotFound();
            }
            var population = await _context.Populations.FindAsync(id);
            if (population == null)
            {
                return NotFound();
            }

            _context.Populations.Remove(population);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PopulationExists(int id)
        {
            return (_context.Populations?.Any(e => e.CityId == id)).GetValueOrDefault();
        }
    }
}
