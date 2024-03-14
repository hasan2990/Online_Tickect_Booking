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

        public async Task<List<PriceInfo>> GetBusesUser(SearchBusesInfo use)
        {
            using (var connection = this._appDbContext.Connection())
            {
                try
                {
                    string query = @"
                    SELECT 
                        b.bus_id, b.bus_name, b.capacity, b.seatCount, r.route_id, r.source_id,
	                    r.destination_id, re.region_name as source,
	                    ree.region_name as destination, r.duration, p.price
                    FROM Buses b
                        JOIN Price p ON b.bus_id = p.bus_id
                        JOIN Routes r ON r.route_id = p.route_id
                        JOIN region re on r.source_id = re.id
	                    JOIN region ree on r.destination_id = ree.id

                    WHERE r.source_id = @source_id AND r.destination_id = @destination_id;
                    ";

                    List<PriceInfo> selectedBusesModelList = new List<PriceInfo>();

                    var result = await connection.QueryAsync<PriceInfo>(query, use);
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
