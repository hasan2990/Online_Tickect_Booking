using Dapper;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Data;
using Online_Ticket_Booking.Repositories.Interfaces;

namespace Online_Ticket_Booking.Repositories.Implemantations
{
    public class BusRepo : IBusRepo
    {
        private readonly AppDbContext _appDbContext;
        public BusRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> BusUser(BusInfo use)
        {
            string query = @"INSERT INTO Buses (bus_name, capacity, type) VALUES (@bus_name, @capacity, @type)";

            int rowsAffected = 0;
            using (var connection = this._appDbContext.Connection())
            {

                rowsAffected = await connection.ExecuteAsync(query, use);

                return rowsAffected;
            }
        }
    }
}
