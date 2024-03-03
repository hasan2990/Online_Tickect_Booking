using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<string> ServiceRegisterUser(User registration);
    }
}
