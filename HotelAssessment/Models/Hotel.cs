using System.ComponentModel.DataAnnotations;

namespace HotelAssessment.Models
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? HotelDescription { get; set; }
        public string? HotelLocation { get; set; }

        public int RoomPrice { get; set; }

        public string? Amenities { get; set; }
        public ICollection<Room>? Rooms { get; set; }
        public ICollection<Staff>? Staffs { get; set; }
        public ICollection<Customer>? Customers { get; set; }
    }
}
