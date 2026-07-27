using GammingCenter.DTOs.AvailableSlotDTO;
using GammingCenter.Models;
using GammingCenter.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("availableSlot")]
    //[Authorize]
    public class AvailableSlotController : ControllerBase
    {
        //apply dependency inversion concept 
        private AvailableSlotService availableSlotService;
        public AvailableSlotController(AvailableSlotService _availableSlotService)
        {
            availableSlotService = _availableSlotService;
        }

        // === Get all slots === 
        //[AllowAnonymous]
        [HttpGet("GettAllSlots")]
        public IActionResult GetAllSlots()
        {
            List<AvailableSlotOutputDTO> result = availableSlotService.GetAllSlots();
            if (result.Count > 0)
            {
                return Ok(result);
            }

            return NoContent(); //204 no data
        }
        // === Get all slot by Id ===
        public IActionResult GetSlotById([FromRoute] int id)
        {
            AvailableSlotOutputDTO slot = availableSlotService.GetSlotById(id);
            if (slot == null)
            {
                return NotFound(); // 404 notfound
            }
            return Ok(slot);   //200 succeeded

        }



        // ====== Add Slot ======
        //[Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public IActionResult Add([FromBody] AvailableSlotInputDTO slot)
        {
            int slotId = availableSlotService.AddSlot(slot);

            return Ok(new { SlotId = slotId });
        }

        // ====== Update Slot ======
        //[Authorize(Roles = "Admin")]
        [HttpPost("UpdateSlots/{SlotId}")]
        public IActionResult UpdateSlot([FromRoute] int SlotId, [FromQuery] DateTime newSlotDate, [FromQuery] int newDuration)
        {
            bool updated = availableSlotService.UpdateSlot(SlotId, newSlotDate, newDuration);
            if (!updated)
                return NotFound();

            return Ok("Updated successfully");
        }

        // ====== Delete Slot ======
        //[Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{SlotId}")]
        public IActionResult DeleteSlot([FromRoute] int SlotId)
        {
            bool deleted = availableSlotService.DeleteSlot(SlotId);

            if (!deleted)
                return NotFound();

            return Ok("deleted successfully");
            //return NoContent();
        }

        // ====== Update Slot Status Available / Unavailable====== 
        //[Authorize(Roles = "Admin")]
        [HttpPut("UpdateStatus/{SlotId}")]
        public IActionResult UpdateStatus(int slotId, bool status)
        {

            bool updated = availableSlotService.UpdateStatus(slotId, status);


            if (!updated)
                return NotFound();


            return NoContent();

        }

        // ====== Search Slot By Date ======
        //[AllowAnonymous]
        [HttpGet("SearchByDate")]
        public IActionResult SearchByDate(DateTime date)
        {

            return Ok(availableSlotService.SearchByDate(date));

        }

        // ====== View Available Slots Only====== 
        //[AllowAnonymous]
        [HttpGet("ViewAvailableSlots")]
        public IActionResult ViewAvailableSlots()
        {
            return Ok(availableSlotService.ViewrAvailableSlots());
        }


    }

}
