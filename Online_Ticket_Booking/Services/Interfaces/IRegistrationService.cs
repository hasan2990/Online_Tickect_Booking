using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Models.Responses;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface IRegistrationService
    {
        Task<ResponseModel> ServiceRegisterUser(User registration);
    }
}
