﻿using Microsoft.AspNetCore.Mvc;
using Online_Ticket_Booking.Models;

using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;


namespace Online_Ticket_Booking.Controllers
{

    [ApiController]
    public class RegistrationController : ControllerBase
    {
        /*private readonly IRegAndLoginRepo _registrationRepository;*/
        private readonly IRegAndLoginService _iRegAndLoginService;

        public RegistrationController(IRegAndLoginService iRegAndLoginService)
        {
            _iRegAndLoginService = iRegAndLoginService;   
        }

        [HttpPost]
        [Route("api/registration")]
        public string Registration(RegistrationModel registration)
        {
            return _iRegAndLoginService.ServiceRegisterUser(registration);
           
        }

        [HttpPost]
        [Route("api/login")]
        public IActionResult Login(LoginModel login)
        {
            var token = _iRegAndLoginService.ServiceLoginUser(login.Email, login.Password);

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(new { Token = token, Message = "Token generated successfully." });
            }
            else
            {
                return BadRequest("Not Found");
            }
        }

        /*private string GenerateToken(string email)
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
        }*/
    }
}
