using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface ILoginRepo
    {
        string LoginUser(string email, string password);
    }
}
