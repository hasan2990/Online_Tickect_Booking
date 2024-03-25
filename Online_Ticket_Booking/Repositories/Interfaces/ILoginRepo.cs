using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Models.Responses;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface ILoginRepo
    {
        Task<bool> CheckEmailExists(string email);
        Task<LoginResponse> LoginUser(Login login);
    }
}
