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



    }
    }

