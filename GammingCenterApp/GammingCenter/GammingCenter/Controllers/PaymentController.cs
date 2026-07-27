using GammingCenter.DTOs.PaymentDTO;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("payment")]
    public class PaymentController : ControllerBase
    {

        private PaymentService paymentService;

        public PaymentController(PaymentService _paymentService)
        {
            paymentService = _paymentService;
        }



        // ======================================= Make Payment ================================= //

        [HttpPost("MakePayment")]
        public IActionResult MakePayment([FromBody] PaymentInputDTO payment)
        {
            int paymentId = paymentService.MakePayment(payment);

            if (paymentId == 0)
                return NotFound();

            return Ok(new { PaymentId = paymentId });
        }



        // =============================== View Payment Details =======================//

        [HttpGet("GetPaymentDetails/{paymentId}")]
        public IActionResult GetPaymentDetails([FromRoute] int paymentId)
        {
            PaymentOutputDTO payment = paymentService.GetPaymentDetails(paymentId);

            if (payment == null)
                return NotFound();

            return Ok(payment);
        }



        // ========================== Update Payment Status ======================//

        [HttpPut("UpdateStatus/{paymentId}")]
        public IActionResult UpdateStatus([FromRoute] int paymentId, [FromBody] UpdatePaymentStatusDTO dto)
        {
            bool updated = paymentService.UpdatePaymentStatus(paymentId, dto);

            if (!updated)
                return NotFound();

            return Ok("Updated successfully");
        }



        // ============================== Print Invoice / Receipt =========================//

        [HttpGet("PrintInvoice/{paymentId}")]
        public IActionResult PrintInvoice([FromRoute] int paymentId)
        {
            PaymentOutputDTO invoice = paymentService.PrintInvoice(paymentId);

            if (invoice == null)
                return NotFound();

            return Ok(invoice);
        }

    }
}