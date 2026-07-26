using GammingCenter.DTOs.GamingDevice;
using GammingCenter.Models;
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

        // 1- Add Device Method
        public void AddGamingDevice(GamingDeviceCreateDto dto)
        {
            GamingDevice device = new GamingDevice
            {
                DeviceName = dto.DeviceName,
                DeviceCode = dto.DeviceCode,
                HourlyPrice = dto.HourlyPrice,
                Status = dto.Status,
                CategoryId = dto.CategoryId,
                RoomId = dto.RoomId
            };

            _repository.AddGamingDevice(device);
        }

        ////////////////////////////////////////////////////////////

        // 2- Update Device Method
        public bool UpdateGamingDevice(
            int deviceId,
            GamingDeviceUpdateDto dto)
        {
            GamingDevice existingDevice =
                _repository.SearchGamingDevice(deviceId);

            // Check if device exists
            if (existingDevice == null)
            {
                return false;
            }

            existingDevice.DeviceName = dto.DeviceName;
            existingDevice.DeviceCode = dto.DeviceCode;
            existingDevice.HourlyPrice = dto.HourlyPrice;
            existingDevice.CategoryId = dto.CategoryId;
            existingDevice.RoomId = dto.RoomId;

            _repository.UpdateGamingDevice(existingDevice);

            return true;
        }

        ////////////////////////////////////////////////////////////

        // 3- Delete Device Method
        public bool DeleteGamingDevice(int deviceId)
        {
            GamingDevice device =
                _repository.SearchGamingDevice(deviceId);

            // Check if device exists
            if (device == null)
            {
                return false;
            }

            _repository.DeleteGamingDevice(device);

            return true;
        }

        ////////////////////////////////////////////////////////////

        // 4- Search Device Method
        public GamingDeviceResponseDto SearchGamingDevice(
            int deviceId)
        {
            GamingDevice device =
                _repository.SearchGamingDevice(deviceId);

            // Check if device exists
            if (device == null)
            {
                return null;
            }

            GamingDeviceResponseDto response =
                new GamingDeviceResponseDto
                {
                    DeviceID = device.DeviceID,
                    DeviceName = device.DeviceName,
                    DeviceCode = device.DeviceCode,
                    HourlyPrice = device.HourlyPrice,
                    Status = device.Status,
                    CategoryId = device.CategoryId,
                    RoomId = device.RoomId
                };

            return response;
        }

        ////////////////////////////////////////////////////////////

        // 5- View Available Devices Method
        public List<GamingDeviceResponseDto> GetAvailableDevices()
        {
            List<GamingDevice> devices =
                _repository.GetAvailableDevice();

            List<GamingDeviceResponseDto> response =
                devices.Select(device =>
                    new GamingDeviceResponseDto
                    {
                        DeviceID = device.DeviceID,
                        DeviceName = device.DeviceName,
                        DeviceCode = device.DeviceCode,
                        HourlyPrice = device.HourlyPrice,
                        Status = device.Status,
                        CategoryId = device.CategoryId,
                        RoomId = device.RoomId
                    }).ToList();

            return response;
        }

        ////////////////////////////////////////////////////////////

        // 6- Change Device Status Method
        public bool ChangeDeviceStatus(
            int deviceId,
            ChangeDeviceStatusDto dto)
        {
            // Validate allowed status
            if (dto.Status != "Available" &&
                dto.Status != "Occupied" &&
                dto.Status != "Maintenance")
            {
                return false;
            }

            // Check if device exists
            GamingDevice device =
                _repository.SearchGamingDevice(deviceId);

            if (device == null)
            {
                return false;
            }

            // Change device status
            device.Status = dto.Status;

            _repository.UpdateGamingDevice(device);

            return true;
        }
    }
}