using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomAmenities
    {
        [Key]
        [ForeignKey("Room")]
        [Display(Name = "Room Type")]
        public int RoomID { get; set; }
        [Key]
        [ForeignKey("Amenities")]
        [Display(Name = "Amenity Type")]
        public int AmenitiesID { get; set; }

        public Room Room { get; set; }
        public Amenities Amenities { get; set; }
    }
}
