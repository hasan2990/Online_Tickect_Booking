using System.ComponentModel.DataAnnotations;

namespace Online_Ticket_Booking.Models
{
    public class RoadInfo
    {
        public int route_id { get; set; }

        [Required(ErrorMessage = "Source is required")]
        public string source { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        public string destination { get; set; }

        public decimal distance { get; set; }

        public decimal duration { get; set; } 
    }
}
