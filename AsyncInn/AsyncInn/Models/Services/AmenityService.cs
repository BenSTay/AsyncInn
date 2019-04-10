using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenityService : IAmenityManager
    {
        private readonly AsyncInnDbContext _context;

        public AmenityService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds an amenity to the dbcontext.
        /// </summary>
        /// <param name="amenity">The amenity being added.</param>
        /// <returns>The result of SaveChangesAsync</returns>
        public async Task CreateAmenity(Amenities amenity)
        {
            await _context.Amenities.AddAsync(amenity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Removes an amenity from the dbcontext.
        /// </summary>
        /// <param name="id">The amenity's id.</param>
        /// <returns>A boolean representing if the delete was successful.</returns>
        public async Task<bool> DeleteAmenity(int id)
        {
            Amenities amenity = await GetAmenity(id);

            if (amenity is null) return false;

            else
            {
                _context.Amenities.Remove(amenity);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        /// <summary>
        /// Gets all amenities in the dbcontext.
        /// </summary>
        /// <returns>A list of amenities.</returns>
        public async Task<List<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        /// <summary>
        /// Gets an amenity from the dbcontext by its id.
        /// </summary>
        /// <param name="id">The amenity's id.</param>
        /// <returns>An amenity.</returns>
        public async Task<Amenities> GetAmenity(int id)
        {
            return await _context.Amenities.FindAsync(id);
        }

        /// <summary>
        /// Updates an existing amenity in the dbcontext.
        /// </summary>
        /// <param name="id">The amenity's id.</param>
        /// <param name="amenity">The new amenity.</param>
        /// <returns>A boolean representing if the update was successful.</returns>
        public async Task<bool> UpdateAmenity(int id, Amenities amenity)
        {
            Amenities old = await GetAmenity(id);
            if (old is null) return false;

            else
            {
                foreach(var prop in typeof(Amenities).GetProperties())
                {
                    var newVal = prop.GetValue(amenity);

                    if (prop.Name != "ID" && newVal != null)
                    {
                        prop.SetValue(old, newVal);
                    }
                }

                _context.Amenities.Update(old);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
