using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        /*With Regex*/

        private readonly IRegistrationRepo _iRegistrationRepo;
        private readonly ILogger<RegistrationService> _logger;


        public readonly string EmailRegex = @"^[0-9a-zA-Z]+([._+-][0-9a-zA-Z]+)*@[0-9a-zA-Z]+\.[a-zA-Z]{2,4}([.][a-zA-Z]{2,3})?$";
        public readonly string PasswordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,10}$";
        public readonly string MobileRegex = @"([1-9]{1}[0-9]{9})$";

        public RegistrationService(IRegistrationRepo iRegistrationRepo, ILogger<RegistrationService> logger)
        {
            _iRegistrationRepo = iRegistrationRepo;
            _logger = logger;
        }

        public async Task<ResponseModel> ServiceRegisterUser(User registration)
        {
            _logger.LogInformation("ServiceRegisterUser Method Calling in Service Layer");

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

        /*Without regrex*/

        /*private readonly IRegistrationRepo _iRegistrationRepo;
        private readonly ILogger<RegistrationService> _logger;
        public RegistrationService(IRegistrationRepo iRegistrationRepo, ILogger<RegistrationService> logger)
        {
            _iRegistrationRepo = iRegistrationRepo;
            _logger = logger;
        }
        public async Task<ResponseModel> ServiceRegisterUser(User registration)
        {
            _logger.LogInformation("ServiceRegisterUser Method Calling in Service Layer");
            ResponseModel response = new ResponseModel();

            var user = await _iRegistrationRepo.RegisterUser(registration);
            if(user != null)
            {
                response.isSuccess = true;
                response.statusMessage = user;
            }
            else
            {
                response.isSuccess = false;
                response.statusMessage = "Registration Failed.";
            }

            return response;

        }*/
    }
}
