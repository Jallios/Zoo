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
    public class DiseaseCardsController : ControllerBase
    {
        private readonly ZooContext _context;

        public DiseaseCardsController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/DiseaseCards
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiseaseCard>>> GetDiseaseCards()
        {
          if (_context.DiseaseCards == null)
          {
              return NotFound();
          }
            return await _context.DiseaseCards.ToListAsync();
        }

        // GET: api/DiseaseCards/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<DiseaseCard>> GetDiseaseCard(int? id)
        {
          if (_context.DiseaseCards == null)
          {
              return NotFound();
          }
            var diseaseCard = await _context.DiseaseCards.FindAsync(id);

            if (diseaseCard == null)
            {
                return NotFound();
            }

            return diseaseCard;
        }

        // PUT: api/DiseaseCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiseaseCard(int? id, DiseaseCard diseaseCard)
        {
            if (id != diseaseCard.IdDisease)
            {
                return BadRequest();
            }

            _context.Entry(diseaseCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiseaseCardExists(id))
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

        // POST: api/DiseaseCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<DiseaseCard>> PostDiseaseCard(DiseaseCard diseaseCard)
        {
          if (_context.DiseaseCards == null)
          {
              return Problem("Entity set 'ZooContext.DiseaseCards'  is null.");
          }
            _context.DiseaseCards.Add(diseaseCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiseaseCard", new { id = diseaseCard.IdDisease }, diseaseCard);
        }

        // DELETE: api/DiseaseCards/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiseaseCard(int? id)
        {
            if (_context.DiseaseCards == null)
            {
                return NotFound();
            }
            var diseaseCard = await _context.DiseaseCards.FindAsync(id);
            if (diseaseCard == null)
            {
                return NotFound();
            }

            _context.DiseaseCards.Remove(diseaseCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiseaseCardExists(int? id)
        {
            return (_context.DiseaseCards?.Any(e => e.IdDisease == id)).GetValueOrDefault();
        }
    }
}
