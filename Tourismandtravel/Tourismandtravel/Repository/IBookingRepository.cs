using System;
using System.Collections.Generic;
using System.Linq;
using Tourismandtravel.Models;


namespace Tourismandtravel.Repositories
{
    public class BookingRepository
    {
        private readonly TourismdbContext _context;

        public BookingRepository(TourismdbContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }
    }
}
