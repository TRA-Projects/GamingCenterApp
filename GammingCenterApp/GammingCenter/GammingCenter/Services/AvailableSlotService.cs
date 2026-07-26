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


        public bool UpdateSlot(int SlotId, DateTime newSlotDate, int newDuration)
        {
            AvailableSlot availableSlot = repo.GetProductById(SlotId);
            if (availableSlot == null)
            {
                return false;
            }
            availableSlot.SlotDate = newSlotDate;
            availableSlot.Duration = newDuration;
            repo.UpdateSlot();
            return true;
        }


        public bool DeleteSlot(int SlotId)
        {
            AvailableSlot availableSlot = repo.GetProductById(SlotId);
            if (availableSlot == null)
            {
                return false;
            }

            repo.DeleteSlot(availableSlot);
            return true;
        }



    }

    }
