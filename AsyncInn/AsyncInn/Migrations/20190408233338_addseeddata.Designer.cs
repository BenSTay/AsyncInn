﻿// <auto-generated />
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AsyncInn.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20190408233338_addseeddata")]
    partial class addseeddata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AsyncInn.Models.Amenities", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Hot Tub"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Mini Bar"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Home Theater"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Virtual Reality Headset"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Dance Floor"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Seattle",
                            Name = "Async Seattle",
                            Phone = "(206) 226-2606",
                            State = "WA",
                            StreetAddress = "123 Easy St"
                        },
                        new
                        {
                            ID = 2,
                            City = "Portland",
                            Name = "Async Portland",
                            Phone = "(503) 553-5303",
                            State = "OR",
                            StreetAddress = "456 Medium Ave"
                        },
                        new
                        {
                            ID = 3,
                            City = "Los Angeles",
                            Name = "Async Angels",
                            Phone = "(213) 223-2313",
                            State = "CA",
                            StreetAddress = "789 Hard Blvd"
                        },
                        new
                        {
                            ID = 4,
                            City = "Chicago",
                            Name = "Chi Town Async Inn",
                            Phone = "(217) 227-2717",
                            State = "IL",
                            StreetAddress = "1234 Main St"
                        },
                        new
                        {
                            ID = 5,
                            City = "Miami",
                            Name = "Hotline Async",
                            Phone = "(305) 335-3505",
                            State = "FL",
                            StreetAddress = "5678 Primary Dr"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID");

                    b.Property<int>("RoomNumber");

                    b.Property<bool>("PetFriendly");

                    b.Property<decimal>("Rate");

                    b.Property<int>("RoomID");

                    b.HasKey("HotelID", "RoomNumber");

                    b.HasIndex("HotelID")
                        .IsUnique();

                    b.HasIndex("RoomID")
                        .IsUnique();

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("AsyncInn.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 0,
                            Name = "Cozy Studio"
                        },
                        new
                        {
                            ID = 2,
                            Layout = 0,
                            Name = "All-Star Studio"
                        },
                        new
                        {
                            ID = 3,
                            Layout = 1,
                            Name = "1 Bedroom Wonder"
                        },
                        new
                        {
                            ID = 4,
                            Layout = 1,
                            Name = "1 Bedroom To Rule Them All"
                        },
                        new
                        {
                            ID = 5,
                            Layout = 2,
                            Name = "2 Bedrooms 2 Furious"
                        },
                        new
                        {
                            ID = 6,
                            Layout = 2,
                            Name = "The Grandmaster's Suite"
                        });
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.Property<int>("AmenitiesID");

                    b.Property<int>("RoomID");

                    b.HasKey("AmenitiesID", "RoomID");

                    b.HasIndex("AmenitiesID")
                        .IsUnique();

                    b.HasIndex("RoomID")
                        .IsUnique();

                    b.ToTable("RoomAmenities");
                });

            modelBuilder.Entity("AsyncInn.Models.HotelRoom", b =>
                {
                    b.HasOne("AsyncInn.Models.Hotel", "Hotel")
                        .WithOne("HotelRoom")
                        .HasForeignKey("AsyncInn.Models.HotelRoom", "HotelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithOne("HotelRoom")
                        .HasForeignKey("AsyncInn.Models.HotelRoom", "RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AsyncInn.Models.RoomAmenities", b =>
                {
                    b.HasOne("AsyncInn.Models.Amenities", "Amenities")
                        .WithOne("RoomAmenities")
                        .HasForeignKey("AsyncInn.Models.RoomAmenities", "AmenitiesID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AsyncInn.Models.Room", "Room")
                        .WithOne("RoomAmenities")
                        .HasForeignKey("AsyncInn.Models.RoomAmenities", "RoomID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}