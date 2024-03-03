using Online_Ticket_Booking.Models;
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

        public async Task<string> ServiceBusUser(Bus use)
        {
            return await _busRepo.BusUser(use);
        }
    }
}
