using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface ILoginService
    {
        string ServiceLoginUser(string email, string password);
    }
}
