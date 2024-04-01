using Online_Ticket_Booking.Middleware;
using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;

namespace Online_Ticket_Booking.Services.Implemantations
{
    public class LoginServiceWithRefreshToken : ILoginServiceWithRefreshToken
    {
        private readonly ILoginRepoWithRefreshToken _repo;
        private CustomAuth _tokenService;

        public LoginServiceWithRefreshToken(ILoginRepoWithRefreshToken repo, CustomAuth tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }
        public async Task<LoginResponseWithRefreshToken> GetUserLoginInfo(UserLoginModel user)
        {
            LoginResponseWithRefreshToken response = new LoginResponseWithRefreshToken();
            UserLoginModel credential = await _repo.GetUserLoginInfo(user.email, user.password);

            if (credential != null && (credential.email == user.email) && credential.password == user.password)
            {

                user.user_id = credential.user_id;
                var token = await _tokenService.AuthenticUser(user);
                credential.accessToken = token.accessToken;
                credential.refreshToken = token.refreshToken;

                credential.password = user.password;
                response.isSuccess = true;
                response.statusMessage = $"Login Success . {user.email} ";
                response.Data = credential;

                return response;


            }
            else
            {
                response.isSuccess = false;
                response.statusMessage = $"Login Faield .";

                return response;
            }
        }

    }
}

