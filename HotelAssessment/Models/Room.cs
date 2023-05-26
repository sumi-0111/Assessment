using System.ComponentModel.DataAnnotations;

namespace HotelAssessment.Models
{
    public class Room
    {
        [Key]
        public int RoomNo { get; set; }
        public string? RoomName { get; set; }
        public int RoomCount { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
