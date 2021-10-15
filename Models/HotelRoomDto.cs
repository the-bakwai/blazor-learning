using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class HotelRoomDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a room name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter occupancy amount")]
        public int Occupancy { get; set; }
        [Range(1,3000, ErrorMessage = "Regular rate must be between 1 and 3000")]
        public double RegularRate { get; set; }
        public string Details { get; set; }
        public string SqFt { get; set; }
    }
}