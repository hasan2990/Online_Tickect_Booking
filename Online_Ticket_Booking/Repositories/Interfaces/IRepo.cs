using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Model1;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface IRepo
    {
        string RegisterUser(Registration registration);
        string GetTokenByEmailAndPassword(string email, string password);
    }
}
