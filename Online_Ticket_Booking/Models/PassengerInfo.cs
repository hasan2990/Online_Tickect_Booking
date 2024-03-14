namespace Online_Ticket_Booking.Models
{
    public class PassengerInfo
    {
        public int booking_id { get; set; }
        public int user_id { get; set; }
        public int bus_id { get; set; }
        public string? phone_number { get; set; }
        public int seat_no { get; set; }
    }
}
