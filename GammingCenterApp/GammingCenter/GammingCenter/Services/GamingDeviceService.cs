using GammingCenter.DTOs.GamingDevice;
using GammingCenter.Repositories;

namespace GammingCenter.Services
{
    public class GamingDeviceService
    {
        // Repository dependency injected through the constructor
        private readonly GamingDeviceRepository _repository;

        public GamingDeviceService(GamingDeviceRepository repository)
        {
            _repository = repository;
        }

        ////////////////////////////////////////////////////////////


        // 1-Add Device Method
        public void AddGamingDevice(GamingDeviceCreateDto dto)
        {
            var device = new GamingDevice
            {
                DeviceName = dto.DeviceName,
                DeviceCode=dto.DeviceCode,
                HourlyPrice=dto.HourlyPrice,
                Status=dto.Status,
                CategoryId=dto.CategoryId,
                RoomId=dto.RoomId

            };

            _repository.AddGamingDevice(device);

        }
    }
}
