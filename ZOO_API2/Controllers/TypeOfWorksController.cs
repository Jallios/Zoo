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
    public class TypeOfWorksController : ControllerBase
    {
        private readonly ZooContext _context;

        public TypeOfWorksController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/TypeOfWorks
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfWork>>> GetTypeOfWorks()
        {
          if (_context.TypeOfWorks == null)
          {
              return NotFound();
          }
            return await _context.TypeOfWorks.ToListAsync();
        }

        // GET: api/TypeOfWorks/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfWork>> GetTypeOfWork(int? id)
        {
          if (_context.TypeOfWorks == null)
          {
              return NotFound();
          }
            var typeOfWork = await _context.TypeOfWorks.FindAsync(id);

            if (typeOfWork == null)
            {
                return NotFound();
            }

            return typeOfWork;
        }

        // PUT: api/TypeOfWorks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeOfWork(int? id, TypeOfWork typeOfWork)
        {
            if (id != typeOfWork.IdTypeOfWork)
            {
                return BadRequest();
            }

            _context.Entry(typeOfWork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfWorkExists(id))
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

        // POST: api/TypeOfWorks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<TypeOfWork>> PostTypeOfWork(TypeOfWork typeOfWork)
        {
          if (_context.TypeOfWorks == null)
          {
              return Problem("Entity set 'ZooContext.TypeOfWorks'  is null.");
          }
            _context.TypeOfWorks.Add(typeOfWork);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeOfWork", new { id = typeOfWork.IdTypeOfWork }, typeOfWork);
        }

        // DELETE: api/TypeOfWorks/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeOfWork(int? id)
        {
            if (_context.TypeOfWorks == null)
            {
                return NotFound();
            }
            var typeOfWork = await _context.TypeOfWorks.FindAsync(id);
            if (typeOfWork == null)
            {
                return NotFound();
            }

            _context.TypeOfWorks.Remove(typeOfWork);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeOfWorkExists(int? id)
        {
            return (_context.TypeOfWorks?.Any(e => e.IdTypeOfWork == id)).GetValueOrDefault();
        }
    }
}
