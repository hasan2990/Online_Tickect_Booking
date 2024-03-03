using System.ComponentModel.DataAnnotations;

namespace Online_Ticket_Booking.Models
{
    public class Route
    {
        public int route_id { get; set; }

        [Required]
        public string source { get; set; }

        [Required]
        public string destination { get; set; }

        public decimal distance { get; set; }

        public TimeSpan duration { get; set; }
    }
}
