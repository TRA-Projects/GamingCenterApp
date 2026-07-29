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
        [AllowAnonymous]
        [HttpGet("GetAllSlots")]
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
        [AllowAnonymous]
        [HttpGet("GetSlotById/{id}")]
        public IActionResult GetSlotById([FromRoute] int id)
        {
            AvailableSlotOutputDTO slot = availableSlotService.GetSlotById(id);

            if (slot == null)
            {
                return NotFound();
            }

            return Ok(slot);
        }



        // ====== Add Slot ======
        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public IActionResult Add([FromBody] AvailableSlotInputDTO slot)
        {
            int slotId = availableSlotService.AddSlot(slot);

            return Ok(new
            {
                Message = "Slot added successfully",
                SlotId = slotId
            });
        }



        // ====== Update Slot ======
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateSlots/{SlotId}")]
        public IActionResult UpdateSlot([FromRoute] int SlotId,[FromQuery] DateTime newSlotDate,[FromQuery] int newDuration)
        {
            bool updated = availableSlotService.UpdateSlot(SlotId, newSlotDate, newDuration);
            if (!updated)
                return NotFound();

            return Ok("Updated successfully");
        }

        // ====== Delete Slot ======
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{SlotId}")]
        public IActionResult DeleteSlot([FromRoute] int SlotId)
        {
            bool deleted = availableSlotService.DeleteSlot(SlotId);

            if (!deleted)
                return NotFound();

            return Ok("deleted successfully");
           
        }

        // ====== Update Slot Status Available / Unavailable====== 
        [Authorize(Roles = "Admin")]
        [HttpPut("UpdateStatus/{SlotId}")]
        public IActionResult UpdateStatus([FromRoute] int slotId, [FromQuery] bool status)
        {

            bool updated = availableSlotService.UpdateStatus(slotId, status);


            if (!updated)
                return NotFound();


            return NoContent();

        }

        // ====== Search Slot By Date ======
        [AllowAnonymous]
        [HttpGet("SearchByDate")]
        public IActionResult SearchByDate([FromQuery]  DateTime date)
        {

            return Ok(availableSlotService.SearchByDate(date));

        }

        // ====== View Available Slots Only====== 
        [AllowAnonymous]
        [HttpGet("ViewAvailableSlots")]
        public IActionResult ViewAvailableSlots()
        {
            return Ok(availableSlotService.ViewrAvailableSlots());
        }


    }

}
