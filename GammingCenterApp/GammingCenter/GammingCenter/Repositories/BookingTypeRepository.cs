using GammingCenter.Models;

namespace GammingCenter.Repositories
{
    public class BookingTypeRepository
    {
        //Allow Repo to access context 
        private readonly GammingCenterContext Context;

        //CONSTRACTOR
        public BookingTypeRepository(GammingCenterContext context)
        {
            Context = context;
        }

        /////////////////////////////////////////////////////////
        
        //1-Add Booking Type
        public void AddBookingType(BookingType bookingType)
        {
            Context.BookingTypes.Add(bookingType);
            Context.SaveChanges();
        }


        /////////////////////////////////////////////////////////

        //2- Update Booking Type
        public void UpdateBookingType(BookingType bookingType)
        {
            Context.BookingTypes.Update(bookingType);
            Context.SaveChanges();
        }



    }
}
