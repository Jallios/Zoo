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
    public class TypeOfAnimalsController : ControllerBase
    {
        private readonly ZooContext _context;

        public TypeOfAnimalsController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/TypeOfAnimals
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfAnimal>>> GetTypeOfAnimals()
        {
          if (_context.TypeOfAnimals == null)
          {
              return NotFound();
          }
            return await _context.TypeOfAnimals.ToListAsync();
        }

        // GET: api/TypeOfAnimals/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfAnimal>> GetTypeOfAnimal(int? id)
        {
          if (_context.TypeOfAnimals == null)
          {
              return NotFound();
          }
            var typeOfAnimal = await _context.TypeOfAnimals.FindAsync(id);

            if (typeOfAnimal == null)
            {
                return NotFound();
            }

            return typeOfAnimal;
        }

        // PUT: api/TypeOfAnimals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeOfAnimal(int? id, TypeOfAnimal typeOfAnimal)
        {
            if (id != typeOfAnimal.IdTypeOfAnimal)
            {
                return BadRequest();
            }

            _context.Entry(typeOfAnimal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOfAnimalExists(id))
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

        // POST: api/TypeOfAnimals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<TypeOfAnimal>> PostTypeOfAnimal(TypeOfAnimal typeOfAnimal)
        {
          if (_context.TypeOfAnimals == null)
          {
              return Problem("Entity set 'ZooContext.TypeOfAnimals'  is null.");
          }
            _context.TypeOfAnimals.Add(typeOfAnimal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeOfAnimal", new { id = typeOfAnimal.IdTypeOfAnimal }, typeOfAnimal);
        }

        // DELETE: api/TypeOfAnimals/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeOfAnimal(int? id)
        {
            if (_context.TypeOfAnimals == null)
            {
                return NotFound();
            }
            var typeOfAnimal = await _context.TypeOfAnimals.FindAsync(id);
            if (typeOfAnimal == null)
            {
                return NotFound();
            }

            _context.TypeOfAnimals.Remove(typeOfAnimal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeOfAnimalExists(int? id)
        {
            return (_context.TypeOfAnimals?.Any(e => e.IdTypeOfAnimal == id)).GetValueOrDefault();
        }
    }
}
