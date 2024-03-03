using System.ComponentModel.DataAnnotations;

namespace Online_Ticket_Booking.Models
{
    public class Bus
    {
        public int bus_id { get; set; }

        [Required(ErrorMessage = "BusName is Required")]
        public string bus_name { get; set; }

        public int capacity { get; set; }

        public string type { get; set; }
    }
}
