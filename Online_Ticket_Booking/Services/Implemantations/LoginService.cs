using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;
using System.Text.Json;


namespace Online_Ticket_Booking.Services.Implemantations
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepo _iLoginRepo;
        private readonly ILogService _ilogService;

        public LoginService(ILoginRepo iLoginRepo, ILogService ilogService)
        {
            _iLoginRepo = iLoginRepo;
            _ilogService = ilogService;
        }
        public async Task<bool> CheckEmailExists(string email)
        {
            return await _iLoginRepo.CheckEmailExists(email);
        }
        public async Task<LoginResponse> ServiceLoginUser(Login login)
        {
            LoginResponse response = new LoginResponse();
            LoginResponse res = await _iLoginRepo.LoginUser(login);
            if (res.token != null)
            {
                var log = new Log
                {
                    ActionDate = DateTime.Now,
                    ActionChanges = "User Login " + login.email + "Successful",
                    JsonPayload = JsonSerializer.Serialize(login.email),
                    IsActive = true,
                };

                var logmsg = await _ilogService.CreateLog(log);

                response.isSuccess = true;
                response.statusMessage = "Token generated successfully.";
                response.token = res.token;
                response.email = res.email;
                response.password = res.password;
                response.username = res.username;
                response.phone_number = res.phone_number;

            }
            else
            {
                response.isSuccess = false;
                response.statusMessage = "Login failed.";
                response.email = res.email;
                response.password = res.password;
                response.username = res.username;
                response.phone_number = res.phone_number;
            }

            return response;
        }
    }
}
