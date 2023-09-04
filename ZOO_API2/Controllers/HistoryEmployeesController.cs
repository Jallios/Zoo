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
    public class HistoryEmployeesController : ControllerBase
    {
        private readonly ZooContext _context;

        public HistoryEmployeesController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/HistoryEmployees
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoryEmployee>>> GetHistoryEmployees()
        {
          if (_context.HistoryEmployees == null)
          {
              return NotFound();
          }
            return await _context.HistoryEmployees.ToListAsync();
        }

        // GET: api/HistoryEmployees/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoryEmployee>> GetHistoryEmployee(int? id)
        {
          if (_context.HistoryEmployees == null)
          {
              return NotFound();
          }
            var historyEmployee = await _context.HistoryEmployees.FindAsync(id);

            if (historyEmployee == null)
            {
                return NotFound();
            }

            return historyEmployee;
        }

        // PUT: api/HistoryEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoryEmployee(int? id, HistoryEmployee historyEmployee)
        {
            if (id != historyEmployee.IdHe)
            {
                return BadRequest();
            }

            _context.Entry(historyEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoryEmployeeExists(id))
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

        // POST: api/HistoryEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<HistoryEmployee>> PostHistoryEmployee(HistoryEmployee historyEmployee)
        {
          if (_context.HistoryEmployees == null)
          {
              return Problem("Entity set 'ZooContext.HistoryEmployees'  is null.");
          }
            _context.HistoryEmployees.Add(historyEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistoryEmployee", new { id = historyEmployee.IdHe }, historyEmployee);
        }

        // DELETE: api/HistoryEmployees/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoryEmployee(int? id)
        {
            if (_context.HistoryEmployees == null)
            {
                return NotFound();
            }
            var historyEmployee = await _context.HistoryEmployees.FindAsync(id);
            if (historyEmployee == null)
            {
                return NotFound();
            }

            _context.HistoryEmployees.Remove(historyEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoryEmployeeExists(int? id)
        {
            return (_context.HistoryEmployees?.Any(e => e.IdHe == id)).GetValueOrDefault();
        }
    }
}
