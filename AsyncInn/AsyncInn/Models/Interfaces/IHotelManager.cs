using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IHotelManager
    {
        // Create
        Task CreateHotel(Hotel hotel);

        // Read
        Task<Hotel> GetHotel(int id);

        // Read All
        Task<List<Hotel>> GetHotels();
        Task<List<HotelRoom>> GetHotelRooms(int hotelId);

        // Update
        Task<bool> UpdateHotel(int id, Hotel hotel);

        // Delete
        Task<bool> DeleteHotel(int id);
    }
}
