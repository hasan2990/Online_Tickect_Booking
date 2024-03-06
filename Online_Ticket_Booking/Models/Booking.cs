using System.ComponentModel.DataAnnotations;
using Online_Ticket_Booking.Models.Authentication;

namespace Online_Ticket_Booking.Models
{
    public class Booking
    {
        public int booking_id { get; set; }

        public int user_id { get; set; }

        public int route_id { get; set; }

        public int bus_id { get; set; }

        [DataType(DataType.Date)]
        public DateTime booking_date { get; set; }

        [DataType(DataType.Date)]
        public DateTime departure_date { get; set; }

        public int seat_number { get; set; }

        public string status { get; set; }

        // Add navigation properties 
        public User User { get; set; }
        public RoadInfo Route { get; set; }
        public BusInfo Bus { get; set; }
    }
}
