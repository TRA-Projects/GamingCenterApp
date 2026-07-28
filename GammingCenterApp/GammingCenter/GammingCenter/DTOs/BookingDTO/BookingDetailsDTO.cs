namespace GammingCenter.DTOs.BookingDTO
{
    public class BookingDetailsDTO
    {
        public int BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        public int VisitorId { get; set; }

        public int GamingDeviceId { get; set; }

        public int BookingTypeId { get; set; }

        public int AvailableSlotId { get; set; }

        public int PlayerNumber { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; }
    }
}