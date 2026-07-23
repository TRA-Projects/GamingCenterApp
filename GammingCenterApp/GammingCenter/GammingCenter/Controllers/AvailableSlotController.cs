using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("availableSlot")]
    [Authorize]
    public class AvailableSlotController : ControllerBase
    {
        //apply dependency inversion concept 
        private AvailableSlotService availableSlotService;
        public AvailableSlotController(AvailableSlotService _availableSlotService)
        {
            availableSlotService = _availableSlotService;
        }

        [HttpPost("Add")]
        public IActionResult AddSlot(AvailableSlot availableSlot)
        {
            int SlotId = availableSlotService.CreateSlots(availableSlot);

            return Ok(new { SlotId = SlotId });

        }

        //[HttpPost("UpdateSlots")]
        //public IActionResult UpdateSlot([FromRoute] int SlotId, [FromQuery] string newSlotDate, [FromQuery] string newDuration)
        //{
        //    bool updated = availableSlotService.UpdateSlot(SlotId, newSlotDate, newDuration)
        //}









    }

}
