using GammingCenter.DTOs.BookingDTO;
using GammingCenter.Models;
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
        //======================================================
        // Display Update Booking page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        // Update booking
        [HttpPost]
        public IActionResult Edit(int id, BookingDTO dto)
        {
            if (ModelState.IsValid)
            {
                bookingService.UpdateBooking(id, dto);

                return RedirectToAction("Index");
            }

            return View(dto);

        }
        //======================================================
        // Cancel Booking

        [HttpPost]
        public IActionResult Cancel(int id)
        {
            bookingService.CancelBooking(id);

            return RedirectToAction("Index");

        }

        //======================================================
        // View Booking Details

        // Display booking details
        [HttpGet]
        public IActionResult Details(int id)
        {
            Booking booking = bookingService.GetBookingDetails(id);


            // Check if booking exists
            if (booking == null)
            {
                return NotFound();
            }


            return View(booking);
        }

        //======================================================
        // View Visitor Bookings

        // Display all bookings for a visitor
        [HttpGet]
        public IActionResult VisitorBookings(int id)
        {
            List<Booking> bookings = bookingService.GetVisitorBookings(id);


            return View(bookings);
        }
    }
}
