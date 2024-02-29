using System.ComponentModel.DataAnnotations;

namespace Online_Ticket_Booking.Models
{
    public class RegistrationModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
