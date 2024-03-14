using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface ILoginRepo
    {
        Task<bool> CheckEmailExists(string email);
        Task<string> LoginUser(string email, string password);
    }
}
