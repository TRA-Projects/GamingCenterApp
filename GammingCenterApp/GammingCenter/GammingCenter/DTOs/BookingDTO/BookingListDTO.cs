namespace GammingCenter.DTOs.BookingDTO
{
    public class BookingListDTO
    {
        public int BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        public string Status { get; set; }

        public decimal TotalPrice { get; set; }
    }
}