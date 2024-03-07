using Dapper;
using Microsoft.Data.SqlClient;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Data;
using Online_Ticket_Booking.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Online_Ticket_Booking.Repositories.Implementations
{
    public class GetBusesRepo : IGetBusesRepo
    {
        private readonly AppDbContext _appDbContext;

        public GetBusesRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<SelectedBusesModel>> GetBusesUser(SearchBusesInfo use)
        {
            using (var connection = this._appDbContext.Connection())
            {
                try
                {
                    string query = @"
                    SELECT b.bus_id, b.bus_name, r.route_id, r.source, r.destination,sb.price
                    FROM Buses b
                    JOIN SelectedBuses sb ON b.bus_id = sb.bus_id
                    JOIN Routes r ON r.route_id = sb.route_id
                    WHERE r.source = @Source AND r.destination = @Destination;
                    ";

                    List<SelectedBusesModel> selectedBusesModelList = new List<SelectedBusesModel>();

                    var result = await connection.QueryAsync<SelectedBusesModel>(query, new { Source = use.source, Destination = use.destination });
                    selectedBusesModelList = result.ToList();

                    return selectedBusesModelList;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
