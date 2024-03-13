namespace Online_Ticket_Booking.Models
{
    public enum PaymentMethod
    {
        bKash,
        Nagad,
        Card
    }

    public class PaymentInfo
    {
        // Common properties
        public int Amount { get; set; }
        public string? Currency { get; set; }
        public string? Description { get; set; }

        // bKash
        public string? bKashPhoneNumber { get; set; }

        //  Nagad
        public string? NagadAccountNumber { get; set; }

        // Card
        public string? CardNumber { get; set; }
        public string? CardHolderName { get; set; }
        public string? CardExpirationDate { get; set; }
        public string? CardCVV { get; set; }
        public int PaymentMethod { get; internal set; }
    }
}

