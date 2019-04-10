using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class RoomService : IRoomManager
    {
        private readonly AsyncInnDbContext _context;

        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a room to the dbcontext.
        /// </summary>
        /// <param name="room">The room being added.</param>
        /// <returns>The result of SaveChangesAsync</returns>
        public async Task CreateRoom(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a room from the dbcontext.
        /// </summary>
        /// <param name="id">The rooms id.</param>
        /// <returns>A boolean representing if the room was deleted.</returns>
        public async Task<bool> DeleteRoom(int id)
        {
            Room room = await GetRoom(id);
            if (room is null) return false;
            else
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        /// <summary>
        /// Gets a room from the dbcontext by its id.
        /// </summary>
        /// <param name="id">The rooms id.</param>
        /// <returns>A room.</returns>
        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        /// <summary>
        /// Gets all amenities for a room.
        /// </summary>
        /// <param name="roomId">The rooms id.</param>
        /// <returns>A list of RoomAmenities</returns>
        public async Task<List<RoomAmenities>> GetRoomAmenities(int roomId)
        {
            return await _context.RoomAmenities
                .Where(c => c.RoomID == roomId)
                .Include(c => c.Amenities)
                .ToListAsync();
        }

        /// <summary>
        /// Gets all rooms in the dbcontext.
        /// </summary>
        /// <returns>A list of rooms.</returns>
        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        /// <summary>
        /// Updates an existing room in the dbcontext.
        /// </summary>
        /// <param name="id">The ID of the room.</param>
        /// <param name="room">The new room.</param>
        /// <returns>A boolean representing if the update was successful.</returns>
        public async Task<bool> UpdateRoom(int id, Room room)
        {
            Room old = await GetRoom(id);
            if (old is null) return false;
            else
            {
                foreach (var prop in typeof(Room).GetProperties())
                {
                    var newVal = prop.GetValue(room);

                    if (prop.Name != "ID" && newVal != null)
                    {
                        prop.SetValue(old, newVal);
                    }
                }

                _context.Rooms.Update(old);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
