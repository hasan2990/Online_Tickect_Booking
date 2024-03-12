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
            BookingResponse response = new BookingResponse();
            response.isSuccess = true;
            response.statusMessage = "Data Found";
            response.bookingList = await _bookingRepo.GetBookingRepoAsync(queryParameters);
            if (response.bookingList.Count == 0)
            {
                await _bookingRepo.InsertBookingRepoAsync(queryParameters);
                response.bookingList = await _bookingRepo.GetBookingRepoAsync(queryParameters);
                response.statusMessage = "Data Inserted";
            }
            return response;
        }
    }
}
