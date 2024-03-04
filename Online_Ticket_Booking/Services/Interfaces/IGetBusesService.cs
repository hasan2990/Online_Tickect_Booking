using Online_Ticket_Booking.Models;

namespace Online_Ticket_Booking.Services.Interfaces
{
    public interface IGetBusesService
    {
        Task<List<SelectedBusesModel>> ServiceGetBuses(SearchBusesInfo use);
    }
}
