using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Implemantations;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;


namespace Online_Ticket_Booking.Services.Implemantations
{
    public class BusService : IBusService
    {
        private readonly IBusRepo _busRepo;

        public BusService(IBusRepo busRepo)
        {
            _busRepo = busRepo;
        }
        public async Task<ResponseModel> ServiceBusUser(BusInfo use)
        {
            ResponseModel response = new ResponseModel();
         
            response.isSuccess = true;
            response.statusMessage = await _busRepo.BusUser(use);

            return response;
        }
    }
}
