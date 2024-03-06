using NuGet.Common;

namespace Online_Ticket_Booking.Models.Responses
{
    public class ResponseModel
    {
        public bool isSuccess { get; set; }
        public string statusMessage { get; set; }
        //public User user { get; set; }
        public string token { get; set; }

    }
}
