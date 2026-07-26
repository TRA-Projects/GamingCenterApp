using GammingCenter.Models;

namespace GammingCenter.Repositories
{
    public class AvailableSlotRepository
    {
        private GammingCenterContext context;


        public AvailableSlotRepository(GammingCenterContext _context)
        {
            context = _context;
        }

        public List<AvailableSlot> GetAllProducts()
        {
            return context.AvailableSlots.ToList();
        }

        public AvailableSlot GetProductById(int id)
        {
            return context.AvailableSlots.FirstOrDefault(p => p.SlotId == id);
        }



        // Add Slot
        public void AddSlot(AvailableSlot slot)
        {
            context.AvailableSlots.Add(slot);

            context.SaveChanges();
        }

        // Update Slot
        public void UpdateSlot()
        {
            context.SaveChanges();
        }

        // Delete Slot
        public void DeleteSlot(AvailableSlot availableSlot)
        {
            context.AvailableSlots.Remove(availableSlot);
            context.SaveChanges();
        }


    }
}
