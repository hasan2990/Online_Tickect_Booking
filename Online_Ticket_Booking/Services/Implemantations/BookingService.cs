using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;

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

            int amountToCharge = CalculateBookingAmount(response.bookingList.Count);

            if (response.bookingList.Count == 0)
            {
                //_bookingRepo.makePayment();
                //_bookingRepo.insertPassenger();

                await _bookingRepo.InsertBookingRepoAsync(queryParameters);
                response.bookingList = await _bookingRepo.GetBookingRepoAsync(queryParameters);
                response.statusMessage = "Data Inserted";
            }
            return response;
        }

        public int CalculateBookingAmount(int cnt)
        {
            return 0;
        }
        /*public async Task<BookingResponse> makePayment(BookingQueryParameters queryParameters)
        {
            BookingResponse response = new BookingResponse();
            return response;
        }
        public async Task<BookingResponse> insertPassenger(BookingQueryParameters queryParameters)
        {
            BookingResponse response = new BookingResponse();
            return response;
        }*/
    }
}


