using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface IRegAndLoginRepo
    {
        string RegisterUser(RegistrationModel registration);
        string LoginUser(string email, string password);
    }
}
