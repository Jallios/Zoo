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
    public class ZoosController : ControllerBase
    {
        private readonly ZooContext _context;

        public ZoosController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/Zoos
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zoo>>> GetZoos()
        {
          if (_context.Zoos == null)
          {
              return NotFound();
          }
            return await _context.Zoos.ToListAsync();
        }

        // GET: api/Zoos/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Zoo>> GetZoo(int? id)
        {
          if (_context.Zoos == null)
          {
              return NotFound();
          }
            var zoo = await _context.Zoos.FindAsync(id);

            if (zoo == null)
            {
                return NotFound();
            }

            return zoo;
        }

        // PUT: api/Zoos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZoo(int? id, Zoo zoo)
        {
            if (id != zoo.IdZoo)
            {
                return BadRequest();
            }

            _context.Entry(zoo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZooExists(id))
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

        // POST: api/Zoos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<Zoo>> PostZoo(Zoo zoo)
        {
          if (_context.Zoos == null)
          {
              return Problem("Entity set 'ZooContext.Zoos'  is null.");
          }
            _context.Zoos.Add(zoo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZoo", new { id = zoo.IdZoo }, zoo);
        }

        // DELETE: api/Zoos/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZoo(int? id)
        {
            if (_context.Zoos == null)
            {
                return NotFound();
            }
            var zoo = await _context.Zoos.FindAsync(id);
            if (zoo == null)
            {
                return NotFound();
            }

            _context.Zoos.Remove(zoo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZooExists(int? id)
        {
            return (_context.Zoos?.Any(e => e.IdZoo == id)).GetValueOrDefault();
        }
    }
}
