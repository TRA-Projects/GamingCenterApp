using GammingCenter.DTOs.RoomDTO;
using GammingCenter.Models;
using GammingCenter.Repositories;

namespace GammingCenter.Services
{
    public class RoomService
    {

        // Repository object used to access room data
        private RoomRepository roomRepo;

        public RoomService(RoomRepository roomRepo)
        {
            // Dependency Injection
            this.roomRepo = roomRepo;
        }

        // Business Logic for creating a room
        public void CreateRoom(RoomDTO dto)
        {
            Room room = new Room();

            // Transfer data from DTO to Model
            room.RoomName = dto.RoomName;
            room.RoomType = dto.RoomType;
            room.Capacity = dto.Capacity;
            room.RoomStatus = dto.RoomStatus;

            // Save room using Repository
            roomRepo.AddRoom(room);
        }
    }
}
