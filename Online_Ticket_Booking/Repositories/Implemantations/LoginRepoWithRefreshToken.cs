using Dapper;
using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Models.Data;
using Online_Ticket_Booking.Repositories.Interfaces;

namespace Online_Ticket_Booking.Repositories.Implemantations
{
    public class LoginRepoWithRefreshToken : ILoginRepoWithRefreshToken
    {
        private readonly AppDbContext _appDbContext;
        public LoginRepoWithRefreshToken(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<UserLoginModel> GetUserLoginInfo(string email, string password)
        {
            UserLoginModel response = null;


            string query = "SELECT * FROM Users WHERE email = @email AND password = @password";


            using (var connection = _appDbContext.Connection())
            {
                response = await connection.QueryFirstOrDefaultAsync<UserLoginModel>(query, new { email = email, password = password });
            }

            return response;
        }
    }
}
