namespace Online_Ticket_Booking.Models.Authentication
{
    public class UserLoginModel
    {
        public int user_id { get; set; }
        public string? username { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
        public bool isActive { get; set; } = true;
        public string? phone_number { get; set; }
        public string? refreshToken { get; set; }
        public string? accessToken { get; set; }
    }
}
