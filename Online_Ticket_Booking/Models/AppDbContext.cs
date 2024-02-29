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
            _configuration = configuration;
            _databaseName = _configuration.GetConnectionString("CrudConnection");
        }
        public IDbConnection Connection() => new SqlConnection(this._databaseName);

    }
}
