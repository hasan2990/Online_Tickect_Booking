using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;

namespace Online_Ticket_Booking.Services.Implemantations
{
    public class RoadService : IRoadService
    {
        private readonly IRoadRepo _roadRepo;
        public RoadService(IRoadRepo roadRepo)
        {
            _roadRepo = roadRepo;
        }

        public async Task<ResponseModel> ServiceRoadUser(RoadInfo use)
        {
            ResponseModel response = new ResponseModel();

            response.isSuccess = true;
            response.statusMessage = await _roadRepo.RoadUser(use);

            return response;
        }
    }
}
