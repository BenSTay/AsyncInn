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

        public async Task CreateRoom(Room room)
        {
            await _context.Rooms.AddAsync(room);
            await _context.SaveChangesAsync();
        }

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

        public async Task<Room> GetRoom(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<List<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

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
