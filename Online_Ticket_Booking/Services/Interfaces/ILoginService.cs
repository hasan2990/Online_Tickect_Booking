using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface ILoginService
    {
        bool CheckEmailExists(string email);
        string ServiceLoginUser(string email, string password);
    }
}
