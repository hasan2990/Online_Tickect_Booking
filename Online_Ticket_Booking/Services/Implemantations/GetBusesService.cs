using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;

namespace Online_Ticket_Booking.Services.Implemantations
{
    public class GetBusesService : IGetBusesService
    {
        private readonly IGetBusesRepo _getBusesRepo;
        public GetBusesService(IGetBusesRepo getBusesRepo)
        {
            _getBusesRepo = getBusesRepo;
        }
        public async Task<List<SelectedBusesModel>> ServiceGetBuses(SearchBusesInfo use)
        {
            return await _getBusesRepo.GetBusesUser(use);
        }
    }
}
