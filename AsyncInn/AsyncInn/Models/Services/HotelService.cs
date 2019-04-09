using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelService : IHotelManager
    {
        private AsyncInnDbContext _context;

        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a hotel to the dbcontext.
        /// </summary>
        /// <param name="hotel">The hotel being added.</param>
        /// <returns>The result of SaveChangesAsync</returns>
        public async Task CreateHotel(Hotel hotel)
        {
            await _context.Hotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes a hotel from the dbcontext.
        /// </summary>
        /// <param name="id">The id of the hotel being removed.</param>
        /// <returns>A boolean representing if the hotel was removed.</returns>
        public async Task<bool> DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);
            if (hotel is null) return false;
            else
            {
                _context.Hotels.Remove(hotel);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        /// <summary>
        /// Gets a hotel from the dbcontext.
        /// </summary>
        /// <param name="id">The id of the hotel.</param>
        /// <returns>The hotel with the given id, if one exists.</returns>
        public async Task<Hotel> GetHotel(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        /// <summary>
        /// Gets all hotels from the dbcontext.
        /// </summary>
        /// <returns>A list of all the hotels, if any exist.</returns>
        public async Task<List<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        /// <summary>
        /// Updates a hotel in the dbcontext.
        /// </summary>
        /// <param name="id">The id of the hotel being updated.</param>
        /// <param name="hotel">The updated hotel.</param>
        /// <returns>A boolean representing if the hotel was updated.</returns>
        public async Task<bool> UpdateHotel(int id, Hotel hotel)
        {
            Hotel old = await GetHotel(id);
            if (old is null) return false;
            else
            {
                foreach (var prop in typeof(Hotel).GetProperties())
                {
                    var newValue = prop.GetValue(hotel);

                    if (prop.Name != "ID" && newValue != null )
                    {
                        prop.SetValue(old, newValue);
                    }
                }
                _context.Hotels.Update(old);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
