using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IRoomManager
    {
        // Create
        Task CreateRoom(Room room);

        // Read
        Task<Room> GetRoom(int id);

        // Read All
        Task<List<Room>> GetRooms();

        // Update
        Task<bool> UpdateRoom(int id, Room room);

        // Delete
        Task<bool> DeleteRoom(int id);
    }
}
