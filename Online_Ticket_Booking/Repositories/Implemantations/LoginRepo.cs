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
        private readonly IConfiguration _configuration;

        public LoginRepo(AppDbContext appDbContext, ILogger<LoginRepo> logger, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
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
                    return "";
                }
            }
        }



        private string GenerateToken(string email)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, email) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}