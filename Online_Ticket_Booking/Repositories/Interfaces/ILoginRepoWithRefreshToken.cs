using Online_Ticket_Booking.Models.Authentication;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface ILoginRepoWithRefreshToken
    {
        public Task<UserLoginModel> GetUserLoginInfo(string email, string password);
    }
}
