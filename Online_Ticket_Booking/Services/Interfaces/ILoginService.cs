using Online_Ticket_Booking.Models.Responses;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface ILoginService
    {
        Task<bool> CheckEmailExists(string email);
        Task<ResponseModel> ServiceLoginUser(string email, string password);
    }
}
