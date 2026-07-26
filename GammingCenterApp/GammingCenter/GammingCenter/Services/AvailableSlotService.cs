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
            AvailableSlot availableSlot = repo.GetSlotById(SlotId);
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
            AvailableSlot availableSlot = repo.GetSlotById(SlotId);
            if (availableSlot == null)
            {
                return false;
            }

            repo.DeleteSlot(availableSlot);
            return true;
        }

        // Update Slot Status
        public bool UpdateStatus(int slotId, bool status)
        {

            AvailableSlot slot = repo.GetSlotById(slotId);


            if (slot == null)
            {
                return false;
            }


            slot.IsAvailable = status;


            repo.Update();


            return true;
        }

        // Search Slot By Date
        public List<AvailableSlot> SearchByDate(DateTime date)
        {
            return repo.SearchByDate(date);
        }

    }

    }
