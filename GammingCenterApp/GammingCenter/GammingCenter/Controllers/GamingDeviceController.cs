using GammingCenter.DTOs.GamingDevice;
using GammingCenter.Services;
using Microsoft.AspNetCore.Mvc;

namespace GammingCenter.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class GamingDeviceController : ControllerBase
    {
        //Allow Controller to Access Service
        private readonly GamingDeviceService _service;

        //constrator
        public GamingDeviceController(GamingDeviceService service)
        {
            _service = service;
        }

        /////////////////////////////////////////////////////////


        //1-Add Gaming Device

        [HttpPost]
        public IActionResult AddGamingDevice(GamingDeviceCreateDto dto)
        {
            _service.AddGamingDevice(dto);

            return Ok("Gaming device added successfully");
        }

        ////////////////////////////////////////////////////////

        // 2. Update Gaming Device 

        [HttpPut("{deviceId}")] //tag
        public IActionResult UpdateGamingDevice(int deviceId , GamingDeviceUpdateDto dto)
        {
            bool result = _service.UpdateGamingDevice(deviceId, dto);

            // Check if the gaming device exists
            if (!result)
            {
                return NotFound("Gaming device not found");

            }

            return Ok("Gaming device Updated successfully");
        }

        ////////////////////////////////////////////////////////

        // 3-Delete Device Method

        [HttpDelete("{deviceId}")]
        public IActionResult DeleteGamingDevice(int deviceId)
        {
            bool result = _service.DeleteGamingDevice(deviceId);

            //validate input
            if (!result)
            {
                return NotFound("Gaming device not found");
            }

            return Ok("Gaming device deleted successfully");
        }

        ////////////////////////////////////////////////////////

        // 4-Search Device Method

        [HttpGet("{deviceId}")]
       public IActionResult SearchGamingDevice(int deviceId)
        {
            GamingDevice device = _service.SearchGamingDevice(deviceId);

            //validate input
            if (device == null)
            {
                return NotFound("Gaming device not found");
            }

            return Ok(device);
        }

        ////////////////////////////////////////////////////////

        // 5-View Available Device Method

        [HttpGet("Available")]
        public IActionResult GetAvailableDevice()
        {
            // The service returns a list of GamingDevice objects
            List<GamingDevice> devices = _service.GetAvailableDevices();

            return Ok(devices);
        }


        ////////////////////////////////////////////////////////

        // 5-change Status Device Method
        [HttpPut("{deviceId}/status")]
        public IActionResult changeDeviceStatus(int deviceId, ChangeDeviceStatusDto dto)
        {
            bool result = _service.changeDeviceStatus(deviceId, dto);

            //validate input
            if (!result)
            {
                return BadRequest("Invalid status or gaming device not found");
            }

            return Ok("Gaming device status changed successfully");
        }



    }


}
