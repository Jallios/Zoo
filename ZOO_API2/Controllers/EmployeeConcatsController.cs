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
    public class EmployeeConcatsController : ControllerBase
    {
        private readonly ZooContext _context;

        public EmployeeConcatsController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeConcats
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeConcat>>> GetEmployeeConcats()
        {
          if (_context.EmployeeConcats == null)
          {
              return NotFound();
          }
            return await _context.EmployeeConcats.ToListAsync();
        }

        // GET: api/EmployeeConcats/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeConcat>> GetEmployeeConcat(int? id)
        {
          if (_context.EmployeeConcats == null)
          {
              return NotFound();
          }
            var employeeConcat = await _context.EmployeeConcats.FindAsync(id);

            if (employeeConcat == null)
            {
                return NotFound();
            }

            return employeeConcat;
        }

        // PUT: api/EmployeeConcats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeConcat(int? id, EmployeeConcat employeeConcat)
        {
            if (id != employeeConcat.IdConcat)
            {
                return BadRequest();
            }

            _context.Entry(employeeConcat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeConcatExists(id))
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

        // POST: api/EmployeeConcats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<EmployeeConcat>> PostEmployeeConcat(EmployeeConcat employeeConcat)
        {
          if (_context.EmployeeConcats == null)
          {
              return Problem("Entity set 'ZooContext.EmployeeConcats'  is null.");
          }
            _context.EmployeeConcats.Add(employeeConcat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeConcat", new { id = employeeConcat.IdConcat }, employeeConcat);
        }

        // DELETE: api/EmployeeConcats/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeConcat(int? id)
        {
            if (_context.EmployeeConcats == null)
            {
                return NotFound();
            }
            var employeeConcat = await _context.EmployeeConcats.FindAsync(id);
            if (employeeConcat == null)
            {
                return NotFound();
            }

            _context.EmployeeConcats.Remove(employeeConcat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeConcatExists(int? id)
        {
            return (_context.EmployeeConcats?.Any(e => e.IdConcat == id)).GetValueOrDefault();
        }
    }
}
