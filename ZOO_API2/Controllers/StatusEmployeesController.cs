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
    public class StatusEmployeesController : ControllerBase
    {
        private readonly ZooContext _context;

        public StatusEmployeesController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/StatusEmployees
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusEmployee>>> GetStatusEmployees()
        {
          if (_context.StatusEmployees == null)
          {
              return NotFound();
          }
            return await _context.StatusEmployees.ToListAsync();
        }

        // GET: api/StatusEmployees/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusEmployee>> GetStatusEmployee(int? id)
        {
          if (_context.StatusEmployees == null)
          {
              return NotFound();
          }
            var statusEmployee = await _context.StatusEmployees.FindAsync(id);

            if (statusEmployee == null)
            {
                return NotFound();
            }

            return statusEmployee;
        }

        // PUT: api/StatusEmployees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusEmployee(int? id, StatusEmployee statusEmployee)
        {
            if (id != statusEmployee.IdStatusEmployee)
            {
                return BadRequest();
            }

            _context.Entry(statusEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusEmployeeExists(id))
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

        // POST: api/StatusEmployees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<StatusEmployee>> PostStatusEmployee(StatusEmployee statusEmployee)
        {
          if (_context.StatusEmployees == null)
          {
              return Problem("Entity set 'ZooContext.StatusEmployees'  is null.");
          }
            _context.StatusEmployees.Add(statusEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusEmployee", new { id = statusEmployee.IdStatusEmployee }, statusEmployee);
        }

        // DELETE: api/StatusEmployees/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusEmployee(int? id)
        {
            if (_context.StatusEmployees == null)
            {
                return NotFound();
            }
            var statusEmployee = await _context.StatusEmployees.FindAsync(id);
            if (statusEmployee == null)
            {
                return NotFound();
            }

            _context.StatusEmployees.Remove(statusEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusEmployeeExists(int? id)
        {
            return (_context.StatusEmployees?.Any(e => e.IdStatusEmployee == id)).GetValueOrDefault();
        }
    }
}
