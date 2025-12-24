using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Supabase;

using ActorsRestService.Models;

namespace ActorsRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private readonly Client _supabase;

        public ActorsController(Client supabase)
        {
            _supabase = supabase;
        }

        // GET: api/Actors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actor>>> GetActor()
        {
            var response = await _supabase
                                    .From<Actor>()
                                    .Get();
            return response.Models;
        }

        // GET: api/Actors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actor>> GetActor(int id)
        {
            var response = await _supabase
                                    .From<Actor>()
                                    .Where(a => a.ActorId == id)
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


        // PUT: api/Actors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActor(long id, Actor newData)
        {
            if (id != newData.ActorId)
            {
                return BadRequest();
            }
            Actor oldActor = await _supabase
                            .From<Actor>()
                            .Where(a => a.ActorId == id)
                            .Single();
            if (oldActor is null)
            {
                return BadRequest();
            }
            oldActor.LastName = newData.LastName;
            oldActor.FirstName = newData.FirstName;
            oldActor.CountryCode = newData.CountryCode;
            oldActor.DateOfBirth = newData.DateOfBirth;
            oldActor.CreatedAt = newData.CreatedAt;
            await _supabase
                    .From<Actor>()
                    .Update(oldActor);
            return NoContent();
        }

        // POST: api/Actors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Actor>> PostActor(Actor actor)
        {
            var ret = await _supabase
                .From<Actor>()
                .Insert(actor);
            long id = 0;
            if ((ret is not null) && (ret.Model is not null))
                id = ret.Model.ActorId;
            return CreatedAtAction("GetActor", new { actor_id = id }, actor);
        }

        // DELETE: api/Actors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActor(long id)
        {
            var response = await _supabase
                                    .From<Actor>()
                                    .Where(a => a.ActorId == id)
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
                    .From<Actor>()
                    .Where(x => x.ActorId == id)
                    .Delete();
            return NoContent();
        }

    }
}
