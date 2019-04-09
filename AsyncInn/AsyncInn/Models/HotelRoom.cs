using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        [Key]
        [ForeignKey("Hotel")]
        [Display(Name = "Hotel")]
        public int HotelID { get; set; }
        [Key]
        [Display(Name = "Room Number")]
        public int RoomNumber { get; set; }
        [ForeignKey("Room")]
        [Display(Name = "Room Type")]
        public int RoomID { get; set; }
        public decimal Rate { get; set; }
        [Display(Name = "Pet Friendly")]
        public bool PetFriendly { get; set; }
        
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
