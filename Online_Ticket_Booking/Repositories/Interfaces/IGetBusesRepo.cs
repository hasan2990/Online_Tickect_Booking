using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Repositories.Interfaces
{
    public interface IGetBusesRepo
    {
        Task<List<PriceInfo>> GetBusesUser(SearchBusesInfo use);
    }
}
