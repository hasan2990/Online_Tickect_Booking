namespace Online_Ticket_Booking.Models.Responses
{
    public class RefreshTokenResponse
    {
        public string? refreshToken { get; set; }
        public string? accessToken { get; set; }
        public string? email { get; set; }
    }
}
