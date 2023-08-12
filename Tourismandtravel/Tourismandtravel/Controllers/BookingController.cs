using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using Tourismandtravel.Models;
using Tourismandtravel.Repository;

namespace Tourismandtravel.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingRepository _bookingRepository;

        public BookingController()
        {
            _bookingRepository = new BookingRepository(new TourismdbContext());
        }

        [HttpGet]
        public ActionResult Index()
        {
            var bookingList = _bookingRepository.GetAllBookings();
            return View(bookingList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _bookingRepository.AddBooking(booking);
                return RedirectToAction("Index");
            }

            return View(booking);
        }
    }
}
