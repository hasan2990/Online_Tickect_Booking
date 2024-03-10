using Dapper;
using Microsoft.Data.SqlClient;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Data;
using Online_Ticket_Booking.Repositories.Interfaces;

namespace Online_Ticket_Booking.Repositories.Implemantations
{
    public class BookingRepo : IBookingRepo
    {
        private readonly AppDbContext _appDbContext;
        public BookingRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Booking>> GetBookingRepoAsync(Booking book)
        {
            using (var connection = this._appDbContext.Connection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = @"
                            SELECT b.booking_id, b.user_id, b.route_id, b.bus_id, b.ending_time, b.seat_no
                            FROM Bookings b
                            JOIN PassengerInfo p ON p.booking_id = b.booking_id
                            WHERE b.seat_no = @r.seat_no;
                            ";


                        var result = await connection.QueryAsync<Booking>(query);

                        if (result != null)
                        {

                        }

                        return result.ToList();
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
}


