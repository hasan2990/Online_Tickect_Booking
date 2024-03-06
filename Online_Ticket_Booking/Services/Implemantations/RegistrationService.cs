using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Online_Ticket_Booking.Services.Implementations
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationRepo _iRegistrationRepo;

        public readonly string EmailRegex = @"^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+\.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$";
        public readonly string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
        public readonly string MobileRegex = @"([1-9]{1}[0-9]{9})$";

        public RegistrationService(IRegistrationRepo iRegistrationRepo)
        {
            _iRegistrationRepo = iRegistrationRepo;
        }

        public async Task<ResponseModel> ServiceRegisterUser(User registration)
        {
            ResponseModel response = new ResponseModel();

            if (!Regex.IsMatch(registration.email, EmailRegex))
            {
                response.isSuccess = false;
                response.statusMessage = "Email Id Not Current Format Ex: hasan@gmail.com";
                return response;
            }

            if (!Regex.IsMatch(registration.password, PasswordRegex))
            {
                response.isSuccess = false;
                response.statusMessage = "Password Current Format Ex: StrongP4ssword";
                return response;
            }

            if (!Regex.IsMatch(registration.phone_number, MobileRegex))
            {
                response.isSuccess = false;
                response.statusMessage = "Phone Number Not Current Format Ex: 01521447311";
                return response;
            }

            response.isSuccess = true;
            response.statusMessage = await _iRegistrationRepo.RegisterUser(registration);

            return response;
        }
    }
}
