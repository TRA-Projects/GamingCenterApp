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
        public  GamingDeviceController(GamingDeviceService service)
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
        public IActionResult UpdateGamingDevice(int deviceId , GamingDeviceUpdateDto dto)
        {
            var result = _service.UpdateGamingDevice(deviceId, dto);

            // Check if the gaming device exists
            if (!result)
            {
                return NotFound("Gaming device not found");

            }

            return Ok("Gaming device deleted successfully");
        }

    }


}
