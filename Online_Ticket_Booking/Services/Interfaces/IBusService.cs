using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface IBusService
    {
        Task<string> ServiceBusUser(BusInfo use);
    }
}
