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
        public LoginService(ILoginRepo iLoginRepo)
        {
            _iLoginRepo = iLoginRepo;
        }
        public async Task<bool> CheckEmailExists(string email)
        {
            return await _iLoginRepo.CheckEmailExists(email);
        }
        public async Task<ResponseModel> ServiceLoginUser(string email, string password)
        {
            ResponseModel response = new ResponseModel();


            var token = await _iLoginRepo.LoginUser(email, password);
            response.isSuccess = true;
            response.statusMessage = "Token generated successfully.";
            response.token = token;


            return response;
        }

    }
}
