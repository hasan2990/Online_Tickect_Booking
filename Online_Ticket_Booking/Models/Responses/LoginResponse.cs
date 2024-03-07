namespace Online_Ticket_Booking.Models.Responses
{
    public class LoginResponse
    {
        public bool isSuccess { get; set; }
        public string statusMessage { get; set; }
        public string token { get; set; }
        public string refreshToken { get; set; }
    }
}
