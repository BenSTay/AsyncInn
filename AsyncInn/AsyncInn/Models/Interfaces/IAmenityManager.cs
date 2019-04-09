using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IAmenityManager
    {
        // Create
        Task CreateAmenity(Amenities amenity);

        // Read
        Task<Amenities> GetAmenity(int id);

        // Read All
        Task<List<Amenities>> GetAmenities();

        // Update
        Task<bool> UpdateAmenity(int id, Amenities amenity);

        // Delete
        Task<bool> DeleteAmenity(int id);
    }
}
