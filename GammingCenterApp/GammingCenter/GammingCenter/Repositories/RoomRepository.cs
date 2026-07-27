using GammingCenter.Models;

namespace GammingCenter.Repositories
{
    public class RoomRepository
    {
        // Database context used to access the database
        private GammingCenterContext context;

        public RoomRepository(GammingCenterContext context)
        {
            // Dependency Injection
            this.context = context;
        }

        // Add a new room to the database
        public void AddRoom(Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
        }

        //========================================================
        // Update Room

        // Find a room by its ID
        public Room GetById(int roomId)
        {
            return context.Rooms.FirstOrDefault(r => r.RoomId == roomId);
        }

        // Save any changes made to the database
        public void Update()
        {
            context.SaveChanges();
        }
        //========================================================
        // View All Rooms

        // Get all rooms from the database
        public List<Room> GetAll()
        {
            return context.Rooms.ToList();
        }

        //========================================================
        // Check Room Availability

        // Check if the room is available
        public bool IsRoomAvailable(int roomId)
        {
            return context.Rooms
                .Any(r => r.RoomId == roomId && r.RoomStatus == "Available");
        }
    }
    }

