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
    public class AviariesController : ControllerBase
    {
        private readonly ZooContext _context;

        public AviariesController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/Aviaries
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aviary>>> GetAviaries()
        {
          if (_context.Aviaries == null)
          {
              return NotFound();
          }
            return await _context.Aviaries.ToListAsync();
        }

        // GET: api/Aviaries/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Aviary>> GetAviary(int? id)
        {
          if (_context.Aviaries == null)
          {
              return NotFound();
          }
            var aviary = await _context.Aviaries.FindAsync(id);

            if (aviary == null)
            {
                return NotFound();
            }

            return aviary;
        }

        // PUT: api/Aviaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAviary(int? id, Aviary aviary)
        {
            if (id != aviary.IdAviary)
            {
                return BadRequest();
            }

            _context.Entry(aviary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AviaryExists(id))
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

        // POST: api/Aviaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<Aviary>> PostAviary(Aviary aviary)
        {
          if (_context.Aviaries == null)
          {
              return Problem("Entity set 'ZooContext.Aviaries'  is null.");
          }
            _context.Aviaries.Add(aviary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAviary", new { id = aviary.IdAviary }, aviary);
        }

        // DELETE: api/Aviaries/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAviary(int? id)
        {
            if (_context.Aviaries == null)
            {
                return NotFound();
            }
            var aviary = await _context.Aviaries.FindAsync(id);
            if (aviary == null)
            {
                return NotFound();
            }

            _context.Aviaries.Remove(aviary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AviaryExists(int? id)
        {
            return (_context.Aviaries?.Any(e => e.IdAviary == id)).GetValueOrDefault();
        }
    }
}
