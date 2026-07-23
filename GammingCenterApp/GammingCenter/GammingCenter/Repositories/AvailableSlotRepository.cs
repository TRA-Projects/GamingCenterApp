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



        public void AddSlots (AvailableSlot availableSlot)
        {
            context.AvailableSlots.Add(availableSlot);
            context.SaveChanges();
        }
    }
}
