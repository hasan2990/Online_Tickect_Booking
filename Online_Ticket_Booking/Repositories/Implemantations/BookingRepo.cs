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
        public async Task<List<Booking>> GetBookingRepoAsync(BookingQueryParameters queryParameters)
        {
            using (var connection = this._appDbContext.Connection())
            {
                //using (var transaction = connection.BeginTransaction())
                //{
                try
                {
                    string query = @"
                    SELECT b.booking_id, b.user_id, b.route_id, b.bus_id, b.ending_time, b.seat_no, b.isBooked
                    FROM Bookings b
                    WHERE (b.bus_id = @bus_id AND b.seat_no = @seat_no AND b.isBooked = 1);
                ";


                    var result = await connection.QueryAsync<Booking>(query, queryParameters);

                    if (result != null)
                    {
                        Console.WriteLine("Number of results: " + result.Count());
                        return result.ToList();
                    }
                    else
                    {
                        return new List<Booking>();
                    }
                    //return result.ToList();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("SQL Error: " + ex.Message);
                    throw new Exception(ex.Message);
                }
                //}
            }
        }
    }
}
