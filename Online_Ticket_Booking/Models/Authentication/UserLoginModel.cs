namespace Online_Ticket_Booking.Models.Authentication
{
    public class UserLoginModel
    {
        public int user_id { get; set; }
        public string? username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isActive { get; set; } = true;
        public string? phone_number { get; set; }
        public string refreshToken { get; set; } = string.Empty;
        public string? accessToken { get; set; } = string.Empty;
    }
}
