using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;
using System.Text.Json;

namespace Online_Ticket_Booking.Services.Implemantations
{
    public class RoadService : IRoadService
    {
        private readonly IRoadRepo _roadRepo;
        private readonly ILogService _ilogService;

        public RoadService(IRoadRepo roadRepo, ILogService ilogService)
        {
            _roadRepo = roadRepo;
            _ilogService = ilogService;
        }

        public async Task<ResponseModel> ServiceRoadUser(RoadInfo use)
        {
            ResponseModel response = new ResponseModel();

            var tmp = await _roadRepo.RoadUser(use);
            if (tmp > 0)
            {
                response.isSuccess = true;
                response.statusMessage = "Route details are added to the database";

                var log = new Log
                {
                    ActionDate = DateTime.Now,
                    ActionChanges = "Roadadded " + use + "Successful",
                    JsonPayload = JsonSerializer.Serialize(use),
                    IsActive = true,
                };
                var logmsg = await _ilogService.CreateLog(log);
            }
            else
            {
                response.isSuccess = false;
                response.statusMessage = "Error";
            }

            return response;
        }
    }
}
