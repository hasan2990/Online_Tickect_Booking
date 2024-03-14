namespace Online_Ticket_Booking.Models.Responses
{
    public class BookingResponse
    {
        public bool isSuccess { get; set; }
        public string? statusMessage { get; set; }
        public List<Booking>? bookingList { get; set; }
    }
}
