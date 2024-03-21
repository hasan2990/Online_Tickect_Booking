using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Implemantations;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

        public async Task<LoginResponse> ServiceLoginUser(string email, string password)
        {
            LoginResponse response = new LoginResponse();

            var token = await _iLoginRepo.LoginUser(email, password);

            if (!string.IsNullOrEmpty(token))
            {
                var log = new Log
                {
                    ActionDate = DateTime.Now,
                    ActionChanges = "User Login " + email + "Successful",
                    JsonPayload = JsonSerializer.Serialize(email),
                    IsActive = true,
                };

                var logmsg = await _ilogService.CreateLog(log);

                response.isSuccess = true;
                response.statusMessage = "Token generated successfully.";
                response.token = token;
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
