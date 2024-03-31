using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Implemantations;
using Online_Ticket_Booking.Services.Interfaces;
using System.Text.Json;

namespace Online_Ticket_Booking.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _bookingRepo;
        private readonly ILogService _ilogService;
        public BookingService(IBookingRepo bookingRepo, ILogService ilogService)
        {
            _bookingRepo = bookingRepo;
            _ilogService = ilogService;
        }

        public async Task<BookingResponse> GetBookingsAsync(BookingQueryParameters queryParameters)
        {
            BookingResponse response = new BookingResponse();

            response.isSuccess = true;
            response.statusMessage = "Data Found. The selected seat is already booked.";
            response.bookingList = await _bookingRepo.GetBookingRepoAsync(queryParameters);

            int amountToCharge = CalculateBookingAmount(response.bookingList.Count);

            if (response.bookingList.Count == 0)
            {
                //_bookingRepo.makePayment();
                //_bookingRepo.insertPassenger();

                await _bookingRepo.InsertBookingRepoAsync(queryParameters);
                response.bookingList = await _bookingRepo.GetBookingRepoAsync(queryParameters);
                var log = new Log
                {
                    ActionDate = DateTime.Now,
                    ActionChanges = "Booking " + queryParameters + "Successful",
                    JsonPayload = JsonSerializer.Serialize(queryParameters),
                    IsActive = true,
                };
                var logmsg = await _ilogService.CreateLog(log);
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


