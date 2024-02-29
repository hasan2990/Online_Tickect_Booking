using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;

namespace Online_Ticket_Booking.Services.Implemantations
{
    public class RegAndLoginService : IRegAndLoginService
    {
        private readonly IRegAndLoginRepo _iRegAndLoginRepo;
        public RegAndLoginService(IRegAndLoginRepo iRegAndLoginRepo)
        {
            _iRegAndLoginRepo = iRegAndLoginRepo;
        }
        public string ServiceRegisterUser(RegistrationModel registration)
        {
            return _iRegAndLoginRepo.RegisterUser(registration);
        }
        public string ServiceLoginUser(string email, string password)
        {
          return _iRegAndLoginRepo.LoginUser(email, password);
        }

    }
}
