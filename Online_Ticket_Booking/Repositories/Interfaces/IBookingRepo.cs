using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface IBookingRepo
    {
        Task<List<Booking>> GetBookingRepoAsync(BookingQueryParameters queryParameters);
        Task<List<Booking>> InsertBookingRepoAsync(BookingQueryParameters queryParameters);

        /* Task<List<Booking>> GetBookingRepoAsync(BookingQueryParameters queryParameters, PaymentInfo paymentInfo);
         Task<List<Booking>> InsertBookingRepoAsync(BookingQueryParameters queryParameters, PaymentInfo paymentInfo);*/
    }
}
