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
        private readonly PaymentService paymentService;
        private readonly EmailService emailService;

        public PaymentController(PaymentService _paymentService, EmailService _emailService)
        {
            paymentService = _paymentService;
            emailService = _emailService;
        }

        // ====== View All Payments ======
        [Authorize(Roles = "Admin")]
        [HttpGet("GetAllPayments")]
        public IActionResult GetAllPayments()
        {
            return Ok(paymentService.GetAllPayments());
        }


        // ==== Make Payment ====

        [AllowAnonymous]
        [HttpPost("MakePayment")]
        public IActionResult MakePayment([FromBody] PaymentInputDTO payment)
        {
            int paymentId = paymentService.MakePayment(payment);
            emailService.SendEmailAsync("example@gmail.com",
            "sucssfully Paid",
            "The payment process is sucssfuly Done");
            return Ok(new
            {
                Message = "Payment completed successfully",
                PaymentId = paymentId
            });
        }

        // ==== View Payment Details by id ====
        [AllowAnonymous]
        [HttpGet("ViewPaymentDetails/{id}")]
        public IActionResult ViewPaymentDetails([FromRoute] int id)
        {
            PaymentOutputDTO payment = paymentService.GetPaymentById(id);

            if (payment == null)
                return NotFound();

            return Ok(payment);
        }

        // ==== Update Payment Status ====
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdatePaymentStatus")]
        public IActionResult UpdatePaymentStatus([FromQuery] int id, [FromQuery] string status)
        {
            bool updated = paymentService.UpdatePaymentStatus(id, status);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        //==== Print Receipt ====
        [AllowAnonymous]
        [HttpGet("PrintReceipt/{id}")]
        public IActionResult PrintReceipt([FromRoute] int id)
        {
            return Ok(paymentService.GetPaymentById(id));
        }

    }
}
