using Microsoft.EntityFrameworkCore.Internal;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;

namespace Online_Ticket_Booking.Services.Implemantations
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepo _iRegistrationRepo;
        public RegistrationService(IRegistrationRepo iRegistrationRepo)
        {
            _iRegistrationRepo = iRegistrationRepo;
        }
        public async Task<string> ServiceRegisterUser(User registration)
        {
            return await _iRegistrationRepo.RegisterUser(registration);
        }
    }
}
