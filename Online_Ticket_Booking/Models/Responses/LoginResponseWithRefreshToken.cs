namespace Online_Ticket_Booking.Models.Responses
{
    public class LoginResponseWithRefreshToken
    {
        public bool isSuccess { get; set; }
        public string? statusMessage { get; set; }
        public dynamic? Data { get; set; }
    }
}
