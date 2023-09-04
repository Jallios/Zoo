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
    public class HoursWeeksController : ControllerBase
    {
        private readonly ZooContext _context;

        public HoursWeeksController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/HoursWeeks
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoursWeek>>> GetHoursWeeks()
        {
          if (_context.HoursWeeks == null)
          {
              return NotFound();
          }
            return await _context.HoursWeeks.ToListAsync();
        }

        // GET: api/HoursWeeks/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<HoursWeek>> GetHoursWeek(int? id)
        {
          if (_context.HoursWeeks == null)
          {
              return NotFound();
          }
            var hoursWeek = await _context.HoursWeeks.FindAsync(id);

            if (hoursWeek == null)
            {
                return NotFound();
            }

            return hoursWeek;
        }

        // PUT: api/HoursWeeks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHoursWeek(int? id, HoursWeek hoursWeek)
        {
            if (id != hoursWeek.IdHours)
            {
                return BadRequest();
            }

            _context.Entry(hoursWeek).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoursWeekExists(id))
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

        // POST: api/HoursWeeks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<HoursWeek>> PostHoursWeek(HoursWeek hoursWeek)
        {
          if (_context.HoursWeeks == null)
          {
              return Problem("Entity set 'ZooContext.HoursWeeks'  is null.");
          }
            _context.HoursWeeks.Add(hoursWeek);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHoursWeek", new { id = hoursWeek.IdHours }, hoursWeek);
        }

        // DELETE: api/HoursWeeks/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHoursWeek(int? id)
        {
            if (_context.HoursWeeks == null)
            {
                return NotFound();
            }
            var hoursWeek = await _context.HoursWeeks.FindAsync(id);
            if (hoursWeek == null)
            {
                return NotFound();
            }

            _context.HoursWeeks.Remove(hoursWeek);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoursWeekExists(int? id)
        {
            return (_context.HoursWeeks?.Any(e => e.IdHours == id)).GetValueOrDefault();
        }
    }
}
