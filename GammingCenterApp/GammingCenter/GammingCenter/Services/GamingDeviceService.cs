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


    }
}
