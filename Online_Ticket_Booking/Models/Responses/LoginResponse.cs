
namespace Online_Ticket_Booking.Models.Responses
{
    public class LoginResponse
    {
        public bool isSuccess { get; set; }
        public string? statusMessage { get; set; }
        public string? token { get; set; }
        public string? username { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? phone_number { get; set; }
        public int user_id { get; set; }
    }
}
