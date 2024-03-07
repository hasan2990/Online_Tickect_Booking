using Online_Ticket_Booking.Repositories.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Models.Data;
namespace Online_Ticket_Booking.Repositories.Implemantations
{
    public class LoginRepo : ILoginRepo
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<LoginRepo> _logger;

        public LoginRepo(AppDbContext appDbContext, ILogger<LoginRepo> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<bool> CheckEmailExists(string email)
        {
            using (var connection = _appDbContext.Connection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<User>(@"SELECT * FROM Users WHERE email = @Email", new { Email = email });
                return user != null;
            }
        }

        public async Task<string> LoginUser(string email, string password)
        {
            _logger.LogInformation("LoginUser Method Calling in Repository Layer");

            using (var connection = this._appDbContext.Connection())
            {
                var user = await connection.QueryFirstOrDefaultAsync<Login>("SELECT * FROM Users WHERE email = @email AND password = @password AND IsActive = 1",
                                                            new { Email = email, Password = password });
                if (user != null)
                {
                    return GenerateToken(user.email);
                }
                else
                {
                    _logger.LogError("Error Occur : Query Not Executed");
                    return "";
                }
            }
        }



        private string GenerateToken(string email)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes("q5WfZ7vfNkyDq6gYhTsW2vGxXKnRE2Py");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {

                    new Claim(JwtRegisteredClaimNames.Email, email),
                    new Claim(JwtRegisteredClaimNames.Sub,email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new
                    SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

       
    }
}
