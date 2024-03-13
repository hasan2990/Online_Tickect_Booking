namespace Online_Ticket_Booking.Models.Responses
{
    public class PaymentResponse
    {
        public bool isSuccess { get; set; } = false;
        public string? statusMessage { get; set; }
    }
}
