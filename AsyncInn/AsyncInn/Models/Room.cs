using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }

    public class Room
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public Layout Layout { get; set; }

        public RoomAmenities RoomAmenities { get; set; }
        public HotelRoom HotelRoom { get; set; }
    }
}
