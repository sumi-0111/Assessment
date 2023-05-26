using System.ComponentModel.DataAnnotations;

namespace HotelAssessment.Models
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string? StaffName { get; set; }
        public Hotel? Hotel { get; set; }
    }
}
