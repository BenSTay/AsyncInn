using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>()
                .HasKey(c => new { c.HotelID, c.RoomNumber });
            modelBuilder.Entity<RoomAmenities>()
                .HasKey(c => new { c.AmenitiesID, c.RoomID });

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel() { ID = 1, City = "Seattle",
                    Name = "Async Seattle", Phone = "(206) 226-2606",
                    State = "WA", StreetAddress = "123 Easy St"},
                new Hotel() { ID = 2, City = "Portland",
                    Name = "Async Portland", Phone = "(503) 553-5303",
                    State = "OR", StreetAddress = "456 Medium Ave"},
                new Hotel() { ID = 3, City = "Los Angeles",
                    Name = "Async Angels", Phone = "(213) 223-2313",
                    State = "CA", StreetAddress = "789 Hard Blvd"},
                new Hotel() { ID = 4, City = "Chicago",
                    Name = "Chi Town Async Inn", Phone = "(217) 227-2717",
                    State = "IL", StreetAddress = "1234 Main St"},
                new Hotel() { ID = 5, City = "Miami",
                    Name = "Hotline Async", Phone = "(305) 335-3505",
                    State = "FL", StreetAddress = "5678 Primary Dr"}
                );

            modelBuilder.Entity<Room>().HasData(
                new Room() { ID = 1, Layout = Layout.Studio,
                    Name = "Cozy Studio"},
                new Room() { ID = 2, Layout = Layout.Studio,
                    Name = "All-Star Studio"},
                new Room() { ID = 3, Layout = Layout.OneBedroom,
                    Name = "1 Bedroom Wonder"},
                new Room() { ID = 4, Layout = Layout.OneBedroom,
                    Name = "1 Bedroom To Rule Them All"},
                new Room() { ID = 5, Layout = Layout.TwoBedroom,
                    Name = "2 Bedrooms 2 Furious"},
                new Room() { ID = 6, Layout = Layout.TwoBedroom,
                    Name = "The Grandmaster's Suite"}
                );

            modelBuilder.Entity<Amenities>().HasData(
                new Amenities() { ID = 1, Name = "Hot Tub"},
                new Amenities() { ID = 2, Name = "Mini Bar"},
                new Amenities() { ID = 3, Name = "Home Theater"},
                new Amenities() { ID = 4, Name = "Virtual Reality Headset"},
                new Amenities() { ID = 5, Name = "Dance Floor"}
                );
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<Amenities> Amenities { get; set; }
    }
}
