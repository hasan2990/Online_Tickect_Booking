using System.Runtime.Serialization;

namespace Online_Ticket_Booking.Repositories.Implemantations
{
    [Serializable]
    internal class CustomizedException : Exception
    {
        private string v1;
        private int v2;

        public CustomizedException()
        {
        }

        public CustomizedException(string? message) : base(message)
        {
        }

        public CustomizedException(string v1, int v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public CustomizedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CustomizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}