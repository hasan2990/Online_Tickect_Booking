/*using Dapper;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Repositories.Interfaces;

namespace Online_Ticket_Booking.Repositories.Implemantations
{
    public class SeatInfoRepo : ISeatInfoRepo
    {
        private readonly AppDbContext _appDbContext;
        public SeatInfoRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> GetSeatInfoAsync(SeatInfo info)
        {
            string query = @"INSERT INTO SeatStatus (col_numb) VALUES (@user_id) WHERE bus_id = @BusInfo.bus_id";  

            int rowsAffected = 0;
            using (var connection = this._appDbContext.Connection())
            {

                rowsAffected = await connection.ExecuteAsync(query, info);

                if (rowsAffected > 0)
                {
                    return "Successful";
                }
                else
                {
                    return "Error";
                }
            }
        }
    }
}
*/