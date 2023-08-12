
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tourismandtravel.Models;
using Tourismandtravel.Repository;

namespace Tourismandtravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly TourismdbContext _context;

        public RoomsController(TourismdbContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var room = await _context.Rooms.FindAsync(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.RoomId)
            {
                return BadRequest();
            }

            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'Hotelroomcontext.Rooms'  is null.");
            }
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = room.RoomId }, room);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return (_context.Rooms?.Any(e => e.RoomId == id)).GetValueOrDefault();
        }
        // GET: api/Rooms/Count
        [HttpGet("Count")]
        public async Task<ActionResult<int>> GetRoomCount()
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }

            int count = await _context.Rooms.CountAsync();
            return count;
        }



        // GET: api/Rooms/Type/{roomType}
        [HttpGet("Type/{roomType}")]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomsByType(string roomType)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }

            // Query the rooms by room type
            var rooms = await _context.Rooms
                .Where(room => room.Room_Type.Equals(roomType, StringComparison.OrdinalIgnoreCase))
                .ToListAsync();

            return rooms;
        }


    }
}
