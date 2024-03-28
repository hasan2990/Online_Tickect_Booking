using Azure;
using Dapper;
using Microsoft.Data.SqlClient;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Data;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Interfaces;
using System.Diagnostics;

namespace Online_Ticket_Booking.Repositories.Implemantations
{
    public class RegionRepository : IRegionRepository
    {
        private readonly AppDbContext _appDbContext;
        public RegionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            List<Region> regionList = new List<Region>();

            using (var connection = this._appDbContext.Connection())
            {
                string query = "SELECT * FROM region";
                try
                {
                    var result = await connection.QueryAsync<Region>(query);
                    regionList = result.ToList();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                    throw;
                }
                return regionList;
            }
        }
    }
}
