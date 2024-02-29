/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("GetData")]
        public string GetData()
        {
            return "GetData Authenticated with JWT";
        }

        [HttpGet]
        [Route("Details")]
        public string Details()
        {
            return "Details Authenticated with JWT";
        }

        [Authorize]
        [HttpPost]
        [Route("AddUser")]
        public string AddUser(Users user)
        {
            return "User added with username " + user.UserName;
        }

    }
}
*/