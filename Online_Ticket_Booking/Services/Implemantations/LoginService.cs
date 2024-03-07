using Azure.Core;
using NuGet.Common;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Implemantations;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;


namespace Online_Ticket_Booking.Services.Implemantations
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _iLoginRepo;
        private readonly ILogger<LoginService> _logger;

        public LoginService(ILoginRepo iLoginRepo, ILogger<LoginService> logger)
        {
            _iLoginRepo = iLoginRepo;
            _logger = logger;

        }
        public async Task<bool> CheckEmailExists(string email)
        {
            return await _iLoginRepo.CheckEmailExists(email);
        }
        public async Task<LoginResponse> ServiceLoginUser(string email, string password)
        {

            _logger.LogInformation("ServiceLoginUser Method Calling in Service Layer");

            LoginResponse response = new LoginResponse();


            var token = await _iLoginRepo.LoginUser(email, password);
          
            if (!string.IsNullOrEmpty(token))
            {
                response.isSuccess = true;
                response.statusMessage = "Token generated successfully.";
                response.token = token;
                //response.refreshToken = refreshToken;
            }
            else
            {
                response.isSuccess = false;
                response.statusMessage = "Login failed.";
            }

            return response;
        }

    }
}
