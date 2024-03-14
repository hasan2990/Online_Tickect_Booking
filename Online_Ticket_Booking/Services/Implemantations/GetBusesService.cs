using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;
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


        public async Task<SelectedBusesResponse> ServiceGetBuses(SearchBusesInfo use)
        {
            SelectedBusesResponse response = new SelectedBusesResponse();
            response.ServiceGetBuses = await _getBusesRepo.GetBusesUser(use);

            if (response.ServiceGetBuses != null && response.ServiceGetBuses.Count > 0)
            {
                response.isSuccess = true;
                response.statusMessage = "Successful";
            }
            else
            {
                response.isSuccess = false;
                response.statusMessage = "No buses found";
            }
            return response;
        }
    }
}
