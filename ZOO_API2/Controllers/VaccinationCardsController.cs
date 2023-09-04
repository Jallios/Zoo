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
    public class VaccinationCardsController : ControllerBase
    {
        private readonly ZooContext _context;

        public VaccinationCardsController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/VaccinationCards
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccinationCard>>> GetVaccinationCards()
        {
          if (_context.VaccinationCards == null)
          {
              return NotFound();
          }
            return await _context.VaccinationCards.ToListAsync();
        }

        // GET: api/VaccinationCards/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<VaccinationCard>> GetVaccinationCard(int? id)
        {
          if (_context.VaccinationCards == null)
          {
              return NotFound();
          }
            var vaccinationCard = await _context.VaccinationCards.FindAsync(id);

            if (vaccinationCard == null)
            {
                return NotFound();
            }

            return vaccinationCard;
        }

        // PUT: api/VaccinationCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccinationCard(int? id, VaccinationCard vaccinationCard)
        {
            if (id != vaccinationCard.IdVaccination)
            {
                return BadRequest();
            }

            _context.Entry(vaccinationCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccinationCardExists(id))
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

        // POST: api/VaccinationCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<VaccinationCard>> PostVaccinationCard(VaccinationCard vaccinationCard)
        {
          if (_context.VaccinationCards == null)
          {
              return Problem("Entity set 'ZooContext.VaccinationCards'  is null.");
          }
            _context.VaccinationCards.Add(vaccinationCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaccinationCard", new { id = vaccinationCard.IdVaccination }, vaccinationCard);
        }

        // DELETE: api/VaccinationCards/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccinationCard(int? id)
        {
            if (_context.VaccinationCards == null)
            {
                return NotFound();
            }
            var vaccinationCard = await _context.VaccinationCards.FindAsync(id);
            if (vaccinationCard == null)
            {
                return NotFound();
            }

            _context.VaccinationCards.Remove(vaccinationCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaccinationCardExists(int? id)
        {
            return (_context.VaccinationCards?.Any(e => e.IdVaccination == id)).GetValueOrDefault();
        }
    }
}
