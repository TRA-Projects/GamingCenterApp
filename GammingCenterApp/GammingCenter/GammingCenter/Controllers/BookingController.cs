using GammingCenter.DTOs.BookingDTO;
using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GammingCenter.Controllers
{
    public class BookingController : Controller
    {
        // Service object used to perform booking operations
        private BookingService bookingService;

        public BookingController(BookingService bookingService)
        {
            // Dependency Injection
            this.bookingService = bookingService;
        }


        //======================================================
        // Create Booking

        // Display Create Booking page
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        // Save a new booking
        [HttpPost]
        public IActionResult Create(CreateBookingDTO dto)
        {
            if (ModelState.IsValid)
            {
                // Get VisitorId from JWT Token
                int visitorId = int.Parse(
                    User.FindFirst(ClaimTypes.NameIdentifier).Value
                );


                // Create booking with logged-in visitor
                bookingService.CreateBooking(dto, visitorId);


                return RedirectToAction("Index");
            }

            return View(dto);
        }


        //======================================================
        // Update Booking

        // Display Update Booking page
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }


        // Update booking
        [HttpPost]
        public IActionResult Edit(int id, UpdateBookingDTO dto)
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

        [HttpGet]
        public IActionResult Details(int id)
        {
            BookingDetailsDTO booking = bookingService.GetBookingDetails(id);


            if (booking == null)
            {
                return NotFound();
            }


            return View(booking);
        }


        //======================================================
        // View Visitor Bookings

        [HttpGet]
        public IActionResult VisitorBookings(int id)
        {
            List<BookingListDTO> bookings =
                bookingService.GetVisitorBookings(id);


            return View(bookings);
        }


        //======================================================
        // Calculate Total Price

        [HttpGet]
        public IActionResult CalculatePrice(int deviceId, int hours)
        {
            decimal totalPrice =
                bookingService.CalculateTotalPrice(deviceId, hours);


            return Json(totalPrice);
        }


        //======================================================
        // Check Device Availability

        [HttpGet]
        public IActionResult CheckAvailability(int deviceId, int slotId)
        {
            bool available =
                bookingService.CheckDeviceAvailability(deviceId, slotId);


            return Json(available);
        }
    }
}