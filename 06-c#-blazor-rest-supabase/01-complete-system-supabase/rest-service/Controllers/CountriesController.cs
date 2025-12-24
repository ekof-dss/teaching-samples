using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Supabase;

using ActorsRestService.Models;

namespace ActorssRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly Client _supabase;

        public CountriesController(Client supabase)
        {
            _supabase = supabase;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountry()
        {
            var response = await _supabase
                                    .From<Country>()
                                    .Get();
            return response.Models;
        }

        // GET: api/Countries/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(long id)
        {
            var response = await _supabase
                                    .From<Country>()
                                    .Where(c => c.CountryId == id)
                                    .Get();
            if (response == null)
            {
                return NotFound();
            }
            if (response.Model == null)
            {
                return NotFound();
            }
            return response.Model;
        }


        // PUT: api/Countries/4
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(long id, Country newData)
        {
            if (id != newData.CountryId)
            {
                return BadRequest();
            }
            Country? oldItem = await _supabase
                            .From<Country>()
                            .Where(a => a.CountryId == id)
                            .Single();
            if (oldItem is null)
            {
                return BadRequest();
            }
            oldItem.CountryId = newData.CountryId;
            oldItem.CountryName = newData.CountryName;
            oldItem.CountryCode = newData.CountryCode;
            oldItem.CreatedAt = newData.CreatedAt;
            oldItem.Population = newData.Population;
            await _supabase
                    .From<Country>()
                    .Update(oldItem);
            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            var ret = await _supabase
                .From<Country>()
                .Insert(country);
            long id = -1;
            if ((ret is not null) && (ret.Model is not null))
                id = ret.Model.CountryId;
            return CreatedAtAction("GetCountry", new { id = id }, country);
        }

        // DELETE: api/Countries/4
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(long id)
        {
            var response = await _supabase
                                    .From<Country>()
                                    .Where(a => a.CountryId == id)
                                    .Get();
            if (response == null)
            {
                return NotFound();
            }
            if (response.Model == null)
            {
                return NotFound();
            }
            await _supabase
                    .From<Country>()
                    .Where(x => x.CountryId == id)
                    .Delete();
            return NoContent();
        }

    }
}
