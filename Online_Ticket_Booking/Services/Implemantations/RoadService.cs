using Online_Ticket_Booking.Models;
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

        public async Task<string> ServiceRoadUser(RoadInfo use)
        {
           return await _roadRepo.RoadUser(use);
        }
    }
}
