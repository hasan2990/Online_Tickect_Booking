using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface IRegAndLoginService
    {
        string ServiceRegisterUser(RegistrationModel registration);
        string ServiceLoginUser(string email, string password);
    }
}
