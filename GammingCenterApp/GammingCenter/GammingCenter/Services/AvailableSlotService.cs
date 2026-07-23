using GammingCenter.Models;
using GammingCenter.Repositories;

namespace GammingCenter.Services
{
    public class AvailableSlotService
    {

        private AvailableSlotRepository repo;

        public AvailableSlotService(AvailableSlotRepository _repo)
        {
            repo = _repo;
        }

        public int CreateSlots(AvailableSlot slot)
        {
            slot.IsAvailable = true;
            repo.AddSlots(slot);

            return slot.SlotId;

        }

    }
}
