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
        ////////////////////////////////////////////////////////////
        

        // 2-Update Device Method
        public bool UpdateGamingDevice(int deviceId, GamingDeviceUpdateDto dto)
        {

            var exisitngdevice = _repository.SearchGamingDevice(deviceId);
            
                //check input
                if(exisitngdevice == null)
                {
                    return false;
                }

                exisitngdevice.DeviceName = dto.DeviceName;
                exisitngdevice.DeviceCode = dto.DeviceCode;
                exisitngdevice.HourlyPrice = dto.HourlyPrice;
                exisitngdevice.CategoryId = dto.CategoryId;
                exisitngdevice.RoomId = dto.RoomId;

                _repository.UpdateGamingDevice(exisitngdevice);

            return true;

            }

        ////////////////////////////////////////////////////////////


        // 3-Delete Device Method
        public bool DeleteGamingDevice(int deviceId)
        {
            var device = _repository.SearchGamingDevice(deviceId);

            //check input
            if(device == null)
            {
                return false;
            }

            _repository.DeleteGamingDevice(device);

            return true;
        }


        ////////////////////////////////////////////////////////////


        // 4-Search Device Method
        public GamingDevice SearchGamingDevice(int deviceId)
        {
            return _repository.SearchGamingDevice(deviceId);
        }



    }
}

