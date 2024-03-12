using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface IBookingRepo
    {
        //Task<List<Booking>> GetBookingRepoAsync(Booking booking_id,Booking seat_no);
        Task<List<Booking>> GetBookingRepoAsync(BookingQueryParameters queryParameters);
        //Task<bool> BookSeatAsync(Booking booking);

    }
}
