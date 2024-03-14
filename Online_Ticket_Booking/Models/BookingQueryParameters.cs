namespace Online_Ticket_Booking.Models
{
    public class BookingQueryParameters
    {
        public int bus_id { get; set; }
        public string? seat_no { get; set; }
        public int user_id { get; set; }
        public int route_id { get; set; }
        public bool isPaid { get; set; }
        //public DateTime ending_time { get; set; }
    }
}
