using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface IBookingService
    {
        Task<BookingResponse> GetBookingsAsync(BookingQueryParameters queryParameters);
        //Task<bool> BookSeatAsync(Booking booking);

    }
}
