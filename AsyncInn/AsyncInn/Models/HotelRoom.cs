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
        public int HotelID { get; set; }
        [Key]
        public int RoomNumber { get; set; }
        [ForeignKey("Room")]
        public int RoomID { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
