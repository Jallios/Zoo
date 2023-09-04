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
    public class SwapStatusController : ControllerBase
    {
        private readonly ZooContext _context;

        public SwapStatusController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/SwapStatus
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SwapStatus>>> GetSwapStatuses()
        {
          if (_context.SwapStatuses == null)
          {
              return NotFound();
          }
            return await _context.SwapStatuses.ToListAsync();
        }

        // GET: api/SwapStatus/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<SwapStatus>> GetSwapStatus(int? id)
        {
          if (_context.SwapStatuses == null)
          {
              return NotFound();
          }
            var swapStatus = await _context.SwapStatuses.FindAsync(id);

            if (swapStatus == null)
            {
                return NotFound();
            }

            return swapStatus;
        }

        // PUT: api/SwapStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSwapStatus(int? id, SwapStatus swapStatus)
        {
            if (id != swapStatus.IdSs)
            {
                return BadRequest();
            }

            _context.Entry(swapStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SwapStatusExists(id))
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

        // POST: api/SwapStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<SwapStatus>> PostSwapStatus(SwapStatus swapStatus)
        {
          if (_context.SwapStatuses == null)
          {
              return Problem("Entity set 'ZooContext.SwapStatuses'  is null.");
          }
            _context.SwapStatuses.Add(swapStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSwapStatus", new { id = swapStatus.IdSs }, swapStatus);
        }

        // DELETE: api/SwapStatus/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSwapStatus(int? id)
        {
            if (_context.SwapStatuses == null)
            {
                return NotFound();
            }
            var swapStatus = await _context.SwapStatuses.FindAsync(id);
            if (swapStatus == null)
            {
                return NotFound();
            }

            _context.SwapStatuses.Remove(swapStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SwapStatusExists(int? id)
        {
            return (_context.SwapStatuses?.Any(e => e.IdSs == id)).GetValueOrDefault();
        }
    }
}
