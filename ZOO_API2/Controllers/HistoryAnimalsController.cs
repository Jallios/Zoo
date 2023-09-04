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
    public class HistoryAnimalsController : ControllerBase
    {
        private readonly ZooContext _context;

        public HistoryAnimalsController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/HistoryAnimals
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryAnimal>>> GetHistoryAnimals()
        {
          if (_context.HistoryAnimals == null)
          {
              return NotFound();
          }
            return await _context.HistoryAnimals.ToListAsync();
        }

        // GET: api/HistoryAnimals/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryAnimal>> GetHistoryAnimal(int? id)
        {
          if (_context.HistoryAnimals == null)
          {
              return NotFound();
          }
            var historyAnimal = await _context.HistoryAnimals.FindAsync(id);

            if (historyAnimal == null)
            {
                return NotFound();
            }

            return historyAnimal;
        }

        // PUT: api/HistoryAnimals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoryAnimal(int? id, HistoryAnimal historyAnimal)
        {
            if (id != historyAnimal.IdHa)
            {
                return BadRequest();
            }

            _context.Entry(historyAnimal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryAnimalExists(id))
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

        // POST: api/HistoryAnimals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<HistoryAnimal>> PostHistoryAnimal(HistoryAnimal historyAnimal)
        {
          if (_context.HistoryAnimals == null)
          {
              return Problem("Entity set 'ZooContext.HistoryAnimals'  is null.");
          }
            _context.HistoryAnimals.Add(historyAnimal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoryAnimal", new { id = historyAnimal.IdHa }, historyAnimal);
        }

        // DELETE: api/HistoryAnimals/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoryAnimal(int? id)
        {
            if (_context.HistoryAnimals == null)
            {
                return NotFound();
            }
            var historyAnimal = await _context.HistoryAnimals.FindAsync(id);
            if (historyAnimal == null)
            {
                return NotFound();
            }

            _context.HistoryAnimals.Remove(historyAnimal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoryAnimalExists(int? id)
        {
            return (_context.HistoryAnimals?.Any(e => e.IdHa == id)).GetValueOrDefault();
        }
    }
}
