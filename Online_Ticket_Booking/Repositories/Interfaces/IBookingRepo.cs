using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface IBookingRepo
    {
        //Task<List<Booking>> GetBookingRepoAsync(Booking booking_id);
        Task<List<Booking>> GetBookingRepoAsync(Booking book);

    }
}
