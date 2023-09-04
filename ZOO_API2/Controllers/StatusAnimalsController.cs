using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZOO_API2.Models;

namespace ZOO_API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusAnimalsController : ControllerBase
    {
        private readonly ZooContext _context;

        public StatusAnimalsController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/StatusAnimals
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusAnimal>>> GetStatusAnimals()
        {
          if (_context.StatusAnimals == null)
          {
              return NotFound();
          }
            return await _context.StatusAnimals.ToListAsync();
        }

        // GET: api/StatusAnimals/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusAnimal>> GetStatusAnimal(int? id)
        {
          if (_context.StatusAnimals == null)
          {
              return NotFound();
          }
            var statusAnimal = await _context.StatusAnimals.FindAsync(id);

            if (statusAnimal == null)
            {
                return NotFound();
            }

            return statusAnimal;
        }

        // PUT: api/StatusAnimals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusAnimal(int? id, StatusAnimal statusAnimal)
        {
            if (id != statusAnimal.IdStatusAnimal)
            {
                return BadRequest();
            }

            _context.Entry(statusAnimal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusAnimalExists(id))
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

        // POST: api/StatusAnimals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<StatusAnimal>> PostStatusAnimal(StatusAnimal statusAnimal)
        {
          if (_context.StatusAnimals == null)
          {
              return Problem("Entity set 'ZooContext.StatusAnimals'  is null.");
          }
            _context.StatusAnimals.Add(statusAnimal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusAnimal", new { id = statusAnimal.IdStatusAnimal }, statusAnimal);
        }

        // DELETE: api/StatusAnimals/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusAnimal(int? id)
        {
            if (_context.StatusAnimals == null)
            {
                return NotFound();
            }
            var statusAnimal = await _context.StatusAnimals.FindAsync(id);
            if (statusAnimal == null)
            {
                return NotFound();
            }

            _context.StatusAnimals.Remove(statusAnimal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusAnimalExists(int? id)
        {
            return (_context.StatusAnimals?.Any(e => e.IdStatusAnimal == id)).GetValueOrDefault();
        }
    }
}
