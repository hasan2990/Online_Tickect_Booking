using System.ComponentModel.DataAnnotations;

namespace Online_Ticket_Booking.Models
{
    public class RoadInfo
    {
        [Required(ErrorMessage = "Source is required")]
        public int source_id { get; set; }

        [Required(ErrorMessage = "Destination is required")]
        public int destination_id { get; set; }

        public decimal distance { get; set; }

        public decimal duration { get; set; }
    }
}
