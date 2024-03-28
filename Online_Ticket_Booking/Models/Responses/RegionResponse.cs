namespace Online_Ticket_Booking.Models.Responses
{
    public class RegionResponse
    {
        public bool isSuccess { get; set; }
        public string? statusMessage { get; set; }
        public List<Region>? listregion { get; set; }

    }
}
