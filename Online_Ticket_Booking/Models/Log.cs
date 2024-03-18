namespace Online_Ticket_Booking.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public DateTime ActionDate { get; set; }
        public string? ActionChanges { get; set; }
        public string? JsonPayload { get; set; }
        public bool IsActive { get; set; }
    }
}
