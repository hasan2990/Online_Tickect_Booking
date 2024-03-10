namespace Online_Ticket_Booking.Models.Responses
{
    public class BookingResponse
    {
        public List<Booking> bookingList { get; set; }
        public bool isSuccess { get; set; }
        public string statusMessage { get; set; }
    }
}
