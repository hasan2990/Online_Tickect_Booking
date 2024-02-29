using Microsoft.Data.SqlClient;
using System.Data;

namespace Online_Ticket_Booking.Models
{
    public class AppDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _databaseName;
        public AppDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._databaseName = this._configuration.GetConnectionString("CrudConnection");
        }

        public object Registrations { get; internal set; }

        public IDbConnection Connection() => new SqlConnection(this._databaseName);

    }
}
