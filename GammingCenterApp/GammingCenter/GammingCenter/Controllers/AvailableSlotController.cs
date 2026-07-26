using GammingCenter.DTOs.AvailableSlotDTO;
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


        // Add Slot
        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public IActionResult Add([FromBody] AvailableSlotDTOs slot)
        {
            int slotId = availableSlotService.AddSlot(slot);

            return Ok(new { SlotId = slotId });
        }
        // Update Slot
        [Authorize(Roles = "Admin")]
        [HttpPost("UpdateSlots/{SlotId}")]
        public IActionResult UpdateSlot([FromRoute] int SlotId, [FromQuery] DateTime newSlotDate, [FromQuery] int newDuration)
        {
            bool updated = availableSlotService.UpdateSlot(SlotId, newSlotDate, newDuration);
            if (!updated)
                return NotFound();

            return Ok("Updated successfully");
        }
        // Delete Slot
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{SlotId}")]
        public IActionResult DeleteSlot([FromRoute] int SlotId)
        {
            bool deleted = availableSlotService.DeleteSlot(SlotId);

            if (!deleted)
                return NotFound();

            return Ok("deleted successfully");
            //return NoContent();
        }

        ///





    }

}
