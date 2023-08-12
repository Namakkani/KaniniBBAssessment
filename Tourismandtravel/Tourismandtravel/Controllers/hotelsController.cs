using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 
using Tourismandtravel.Data;
using Tourismandtravel.Models;

namespace Tourismandtravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class hotelsController : ControllerBase
    {
        private readonly TourismdbContext _context;

        public hotelsController(TourismdbContext context)
        {
            _context = context;
        }

        // GET: api/hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            return await _context.Hotels.ToListAsync();
        }

        // GET: api/hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotel(int id)
        {
            if (_context.hotels == null)
            {
                return NotFound();
            }
            var Hotel = await _context.Hotels.FindAsync(id);

            if (Hotel == null)
            {
                return NotFound();
            }

            return Hotel;
        }

        // PUT: api/hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel Hotel)
        {
            if (id != Hotel.HotelId)
            {
                return BadRequest();
            }

            _context.Entry(Hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
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

        // POST: api/hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Hotel>> Posthotel(Hotel Hotel)
        {
            if (_context.Hotels == null)
            {
                return Problem("Entity set 'Tourismdbcontext.Hotels'  is null.");
            }
            _context.Hotels.Add(Hotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotel", new { id = Hotel.HotelId }, Hotel);
        }

        // DELETE: api/hotels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (_context.Hotels == null)
            {
                return NotFound();
            }
            var Hotel = await _context.Hotels.FindAsync(id);
            if (Hotel == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(Hotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelExists(int id)
        {
            return (_context.Hotels?.Any(e => e.HotelId == id)).GetValueOrDefault();
        }
    }
}
