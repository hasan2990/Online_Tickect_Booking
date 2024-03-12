namespace Online_Ticket_Booking.Models.Responses
{
    public class SelectedBusesResponse
    {
        public List<PriceInfo>? ServiceGetBuses { get; set; }
        public bool isSuccess { get; set; }
        public string? statusMessage { get; set; }
    }
}
