using GammingCenter.DTOs.AvailableSlotDTO;
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
        // Add Slot
        public int AddSlot(AvailableSlotDTOs dto)
        {
            AvailableSlot slot = new AvailableSlot();

            slot.Duration = dto.Duration;
            slot.SlotDate = dto.SlotDate;

            // default when creating new slot
            slot.IsAvailable = true;

            repo.AddSlot(slot);

            return slot.SlotId;
        }

        // Update Slot
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

        // Delete Slot
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
