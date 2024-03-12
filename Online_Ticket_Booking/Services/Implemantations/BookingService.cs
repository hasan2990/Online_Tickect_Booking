using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace Online_Ticket_Booking.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _bookingRepo;

        public BookingService(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public async Task<BookingResponse> GetBookingsAsync(BookingQueryParameters queryParameters)
        {
            try
            {
                var bookings = await _bookingRepo.GetBookingRepoAsync(queryParameters);
                return new BookingResponse
                {
                    bookingList = bookings,
                    isSuccess = true,
                    statusMessage = "Bookings retrieved successfully."
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new BookingResponse
                {
                    bookingList = null,
                    isSuccess = false,
                    statusMessage = "Failed to retrieve bookings."
                };
            }
        }

        /*public async Task<bool> BookSeatAsync(Booking booking)
        {
            try
            {
                return await _bookingRepo.BookSeatAsync(booking);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }*/
    }
}
