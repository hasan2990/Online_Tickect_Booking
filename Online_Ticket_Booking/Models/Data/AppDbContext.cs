using Microsoft.Data.SqlClient;
using System.Data;

namespace Online_Ticket_Booking.Models.Data
{
    public class AppDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string? _databaseName;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _databaseName = _configuration.GetConnectionString("CrudConnection");
        }

        public object? Users { get; internal set; }


        public IDbConnection Connection() => new SqlConnection(_databaseName);

    }
}
