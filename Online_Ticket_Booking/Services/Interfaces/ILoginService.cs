using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface ILoginService
    {
        Task<bool> CheckEmailExists(string email);
        Task<string> ServiceLoginUser(string email, string password);
    }
}
