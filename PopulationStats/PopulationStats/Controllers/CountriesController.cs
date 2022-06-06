using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using PopulationStats.Models;
using Newtonsoft.Json;


namespace PopulationStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly PopuContext _context;

        public CountriesController(PopuContext context)
        {
            _context = context;
        }






        //// get external api 
        ////[HttpGet]
        //[HttpGet]
        //public async Task<IActionResult> GetByIdAync()
        //{
        //    var client = new RestClient($"https://countriesnow.space/api/v0.1/countries/population");
        //    var request = new RestRequest();
        //    RestResponse response = await client.ExecuteAsync(request);
        //    dynamic responseContent = JsonConvert.DeserializeObject(response.Content);
        //    Console.WriteLine(responseContent);
        //    //TODO: transform the response here to suit your needs
        //    string data = "";
        //    return Ok(responseContent);
        //}

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {

            var client = new RestClient($"https://countriesnow.space/api/v0.1/countries/population");
            var request = new RestRequest();
            RestResponse response = await client.ExecuteAsync(request);
            dynamic responseContent = JsonConvert.DeserializeObject(response.Content);
            Console.WriteLine(responseContent);

            if (_context.Countries == null)
          {
              return NotFound();
          }
            return await _context.Countries.ToListAsync();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
          if (_context.Countries == null)
          {
              return NotFound();
          }
            var country = await _context.Countries.FindAsync(id);

            if (country == null)
            {
                return NotFound();
            }

            return country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.CountryId)
            {
                return BadRequest();
            }

            _context.Entry(country).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
          if (_context.Countries == null)
          {
              return Problem("Entity set 'PopuContext.Countries'  is null.");
          }
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCountry), new { id = country.CountryId }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (_context.Countries == null)
            {
                return NotFound();
            }
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return (_context.Countries?.Any(e => e.CountryId == id)).GetValueOrDefault();
        }
    }
}
