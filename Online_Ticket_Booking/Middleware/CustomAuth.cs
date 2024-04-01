using Microsoft.IdentityModel.Tokens;
using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Models.Responses;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Online_Ticket_Booking.Middleware
{
    public class CustomAuth
    {
        private readonly IConfiguration _configuration;
        public CustomAuth(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<RefreshTokenResponse> AuthenticUser(UserLoginModel user)
        {
            return await GenerateToken(user.email);
        }
        public async Task<RefreshTokenResponse> GenerateToken(string email)
        {

            var security_key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credential = new SigningCredentials(security_key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], null,
                    expires: DateTime.UtcNow.AddMinutes(15),
                    signingCredentials: credential

                );
            var refreshToken = await GenerateRefreshToken(email);

            RefreshTokenResponse refreshTokenResponse = new RefreshTokenResponse();

            refreshTokenResponse.accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            refreshTokenResponse.refreshToken = refreshToken;
            return refreshTokenResponse;
        }

        private async Task<string> GenerateRefreshToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:RefreshTokenKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, email)
                }),
                Expires = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Jwt:RefreshTokenExpirationTime"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public async Task<string> ExtractUserIdFromRefreshToken(string refreshToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:RefreshTokenKey"]);


                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };


                var claimsPrincipal = tokenHandler.ValidateToken(refreshToken, tokenValidationParameters, out _);


                var email = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                return email;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

    }
}
