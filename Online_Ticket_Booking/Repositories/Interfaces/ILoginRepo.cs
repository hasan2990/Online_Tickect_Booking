using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface ILoginRepo
    {
        bool CheckEmailExists(string email);
        string LoginUser(string email, string password);

    }
}
