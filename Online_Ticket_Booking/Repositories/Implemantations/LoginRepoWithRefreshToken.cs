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
            string query = "SELECT * FROM Users WHERE email = @Email AND password = @Password";

            using (var connection = _appDbContext.Connection())
            {
                var response = await connection.QueryFirstOrDefaultAsync<UserLoginModel>(query, new { Email = email, Password = password });
                return response ?? throw new Exception("User not found."); // Throw exception if response is null
            }
        }

    }
}
