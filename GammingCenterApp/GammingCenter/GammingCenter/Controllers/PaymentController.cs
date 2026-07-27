using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static GammingCenter.DTOs.PaymentDTO.PaymentDTO;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("payment")]
    public class PaymentController : ControllerBase
    {
        //constructor - DI
        private PaymentService paymentService;

        public PaymentController(PaymentService _paymentService)
        {
            paymentService = _paymentService;
        }

        private EmailService emailService;
        public PaymentController(EmailService _EmailService)
        {
            emailService = _EmailService;
        }

        // ====== View All Payments ======
        [HttpGet("GetAllPayments")]
        public IActionResult GetAllPayments()
        {
            return Ok(paymentService.GetAllPayments());
        }


        // ==== Make Payment ====

        //[Authorize(Roles = "Admin")]
        [HttpPost("MakePayment")]
        public IActionResult MakePayment( PaymentInputDTO payment)
        {
            int paymentId = paymentService.MakePayment(payment);
            emailService.SendEmailAsync("Email To:example@gmail.com",
            "subject:sucssfully Paid",
            "The payment process is sucssfuly Done");
            return Ok(new { PaymentId = paymentId });
        }

        // ==== View Payment Details by id ====
        [HttpGet("ViewPaymentDetails/{id}")]
        public IActionResult ViewPaymentDetails(int id)
        {
            PaymentOutputDTO payment = paymentService.GetPaymentById(id);

            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        // ==== Update Payment Status ====
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdatePaymentStatus")]
        public IActionResult UpdatePaymentStatus(int id, string status)
        {
            bool updated = paymentService.UpdatePaymentStatus(id, status);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        //==== Print Receipt ====
        [HttpGet("PrintReceipt")]
        public IActionResult PrintReceipt(int id)
        {
            return Ok(paymentService.GetPaymentById(id));
        }

    }
}
