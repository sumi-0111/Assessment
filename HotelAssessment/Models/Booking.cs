using System.ComponentModel.DataAnnotations;

namespace HotelAssessment.Models
{
    public class Booking
    {
        [Key]
        public int StaffId { get; set; }
        public string? bookingPerson { get; set; }

        public int NoOfDays { get; set; }

        public double phNo { get; set; }
        public DateTime Entry { get; set; }
        public DateTime Exit { get; set; }
        public Hotel? Hotel { get; set; }

        public Hotel? Room { get; set; }
        public Hotel? Customer { get; set; }

    }
}
