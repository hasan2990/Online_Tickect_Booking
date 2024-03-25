using Online_Ticket_Booking.Repositories.Interfaces;
using Dapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Models.Data;
using Online_Ticket_Booking.Models.Responses;
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

        public async Task<LoginResponse> LoginUser(Login login)
        {
            LoginResponse response = new LoginResponse();
            using (var connection = this._appDbContext.Connection())
            {
                var qr = await connection.QueryFirstOrDefaultAsync<User>("SELECT * FROM Users WHERE email = @Email AND password = @Password AND IsActive = 1",
                                                            new { Email = login.email, Password = login.password });
                if (qr != null)
                {
                    response.username = qr.username;
                    response.email = qr.email;
                    response.password = qr.password;
                    response.phone_number = qr.phone_number;
                    if (qr.email != null)
                    {
                        response.token = GenerateToken(qr.email);
                    }
                    else
                    {
                        response.statusMessage = "Invalid credentials.";
                    }
                }
                else
                {
                    response.isSuccess = false;
                    response.statusMessage = "User not found or invalid credentials.";
                }

                return response;
            }
        }


        private string GenerateToken(string email)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, email) };

#pragma warning disable CS8604 // Possible null reference argument.
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
#pragma warning restore CS8604 // Possible null reference argument.
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}