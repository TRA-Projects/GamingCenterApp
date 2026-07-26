using GammingCenter.DTOs.BookingDTO;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    public class BookingController : Controller
    {
        //create booking
        // Service object used to perform booking operations
        private BookingService bookingService;

        public BookingController(BookingService bookingService)
        {
            // Dependency Injection
            this.bookingService = bookingService;
        }

        // Display Create Booking page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Save a new booking
        [HttpPost]
        public IActionResult Create(BookingDTO dto)
        {
            if (ModelState.IsValid)
            {
                bookingService.CreateBooking(dto);

                return RedirectToAction("Index");
            }

            return View(dto);
        }
    }
}
