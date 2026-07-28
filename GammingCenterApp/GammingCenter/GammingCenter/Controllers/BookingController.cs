using GammingCenter.DTOs.BookingDTO;
using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GammingCenter.Controllers
{
    public class BookingController : Controller
    {
        private BookingService bookingService;


        public BookingController(BookingService bookingService)
        {
            this.bookingService = bookingService;
        }


        //======================================================
        // Create Booking

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(
            [FromBody] CreateBookingDTO dto)
        {
            if (ModelState.IsValid)
            {
                int visitorId = int.Parse(
                    User.FindFirst(ClaimTypes.NameIdentifier).Value
                );


                bookingService.CreateBooking(dto, visitorId);

                return RedirectToAction("Index");
            }

            return View(dto);
        }



        //======================================================
        // Update Booking


        [HttpGet]
        public IActionResult Edit(
            [FromRoute] int id)
        {
            return View();
        }



        [HttpPost]
        public IActionResult Edit(
            [FromRoute] int id,
            [FromBody] UpdateBookingDTO dto)
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
        public IActionResult Cancel(
            [FromRoute] int id)
        {
            bookingService.CancelBooking(id);

            return RedirectToAction("Index");
        }



        //======================================================
        // View Booking Details


        [HttpGet]
        public IActionResult Details(
            [FromRoute] int id)
        {
            BookingDetailsDTO booking =
                bookingService.GetBookingDetails(id);


            if (booking == null)
            {
                return NotFound();
            }


            return View(booking);
        }



        //======================================================
        // View Visitor Bookings


        [HttpGet]
        public IActionResult VisitorBookings(
            [FromRoute] int id)
        {
            List<BookingListDTO> bookings =
                bookingService.GetVisitorBookings(id);


            return View(bookings);
        }



        //======================================================
        // Calculate Total Price


        [HttpGet]
        public IActionResult CalculatePrice(
            [FromRoute] int deviceId,
            [FromRoute] int hours)
        {
            decimal totalPrice =
                bookingService.CalculateTotalPrice(deviceId, hours);


            return Json(totalPrice);
        }



        //======================================================
        // Check Device Availability


        [HttpGet]
        public IActionResult CheckAvailability(
            [FromRoute] int deviceId,
            [FromRoute] int slotId)
        {
            bool available =
                bookingService.CheckDeviceAvailability(deviceId, slotId);


            return Json(available);
        }
    }
}