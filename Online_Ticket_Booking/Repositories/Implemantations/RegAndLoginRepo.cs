using Online_Ticket_Booking.Repositories.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Online_Ticket_Booking.Models;
using Microsoft.Data.SqlClient;
namespace Online_Ticket_Booking.Repositories.Implemantations
{
    public class RegAndLoginRepo : IRegAndLoginRepo
    {
        /*private readonly IConfiguration _configuration;
        public RegAndLoginRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string RegisterUser(RegistrationModel registration)
        {
            string connectionString = _configuration.GetConnectionString("CrudConnection");

            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var query = "INSERT INTO Registration (UserName, Password, Email, IsActive) VALUES (@UserName, @Password, @Email, @IsActive)";
                int rowsAffected = con.Execute(query, registration);

                if (rowsAffected > 0)
                {
                    return ("Registration successful.");
                }
                else
                {
                    return ("Registration failed due to invalid data.");
                }
            }
        }
        public string LoginUser(string email, string password)
        {
            string connectionString = _configuration.GetConnectionString("CrudConnection");
            using (var con = new SqlConnection(connectionString))
            {
                con.Open();
                var user = con.QueryFirstOrDefault<LoginModel>("SELECT * FROM Registration WHERE Email = @Email AND Password = @Password AND IsActive = 1",
                                                            new { Email = email, Password = password });

                if (user != null)
                {
                    return GenerateToken(user.Email);
                }
                else
                {
                    return "";
                }
            }
        }*/

        private readonly AppDbContext _appDbContext;
        public RegAndLoginRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string RegisterUser(RegistrationModel registration)
        {
            string query = "INSERT INTO Registration (UserName, Password, Email, IsActive) VALUES (@UserName, @Password, @Email, @IsActive)";

            int rowsAffected = 0;
            using (var connection = this._appDbContext.Connection())
            {

                rowsAffected = connection.Execute(query, registration);

                if (rowsAffected > 0)
                {
                    return "Data Inserted";
                }
                else
                {
                    return "Error";
                }
            }
        }
        public string LoginUser(string email, string password)
        {
            using (var connection = this._appDbContext.Connection())
            {
                var user = connection.QueryFirstOrDefault<LoginModel>("SELECT * FROM Registration WHERE Email = @Email AND Password = @Password AND IsActive = 1",
                                                            new { Email = email, Password = password });
                if (user != null)
                {
                    return GenerateToken(user.Email);
                }
                else
                {
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
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new
                    SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
    }
}
