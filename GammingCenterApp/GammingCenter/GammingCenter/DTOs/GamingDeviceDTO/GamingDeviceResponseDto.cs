namespace GammingCenter.DTOs.GamingDevice
{
    public class GamingDeviceResponseDto
    {
        public int DeviceID { get; set; }

        public string DeviceName { get; set; }

        public string DeviceCode { get; set; }

        public decimal HourlyPrice { get; set; }

        public string Status { get; set; }

        public int CategoryId { get; set; }

        public int RoomId { get; set; }
    }
}