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

        //========================================================
        // Update Room

        // Business Logic for updating room information
        public void UpdateRoom(int roomId, RoomDTO dto)
        {
            // Retrieve room from database
            Room room = roomRepo.GetById(roomId);

            // Check if room exists
            if (room == null)
            {
                return;
            }

            // Update room information
            room.RoomName = dto.RoomName;
            room.RoomType = dto.RoomType;
            room.Capacity = dto.Capacity;
            room.RoomStatus = dto.RoomStatus;

            // Save changes
            roomRepo.Update();
        }
    }
}
