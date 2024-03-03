using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;

namespace Online_Ticket_Booking.Services.Implemantations
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _iLoginRepo;
        public LoginService(ILoginRepo iLoginRepo)
        {
            _iLoginRepo = iLoginRepo;
        }
        public string ServiceLoginUser(string email, string password)
        {
          return _iLoginRepo.LoginUser(email, password);
        }

    }
}
