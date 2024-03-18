using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;
using System.Text.Json;

namespace Online_Ticket_Booking.Services.Implemantations
{
    public class GetBusesService : IGetBusesService
    {
        private readonly IGetBusesRepo _getBusesRepo;
        private readonly ILogService _ilogService;

        public GetBusesService(IGetBusesRepo getBusesRepo, ILogService ilogService)
        {
            _getBusesRepo = getBusesRepo;
            _ilogService = ilogService;
        }


        public async Task<SelectedBusesResponse> ServiceGetBuses(SearchBusesInfo use)
        {
            SelectedBusesResponse response = new SelectedBusesResponse();
            response.ServiceGetBuses = await _getBusesRepo.GetBusesUser(use);

            if (response.ServiceGetBuses != null && response.ServiceGetBuses.Count > 0)
            {
                var log = new Log
                {
                    ActionDate = DateTime.Now,
                    ActionChanges = "GetAllBuses " + use + "Successful",
                    JsonPayload = JsonSerializer.Serialize(use),
                    IsActive = true,
                };
                var logmsg = await _ilogService.CreateLog(log);
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
