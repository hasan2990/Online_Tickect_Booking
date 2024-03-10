using System;
using System.Threading.Tasks;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Services.Interfaces;
using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _bookingRepo;

        public BookingService(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public async Task<BookingResponse> GetBookingsAsync(Booking book)
        {
            try
            {
                var bookingList = await _bookingRepo.GetBookingRepoAsync(book);
                if(bookingList.Count == 0)
                {
                    return new BookingResponse
                    {
                        bookingList = bookingList,
                        isSuccess = true,
                        statusMessage = "Bookings retrieved successfully."
                    };
                }
                return new BookingResponse
                {
                    bookingList = bookingList,
                    isSuccess = true,
                    statusMessage = "Already booked"
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
    }
}
