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
            try
            {
                using (var connection = _appDbContext.Connection()){
                   // connection.Open();
                    string selectQuery = @"
                        SELECT b.booking_id, b.user_id, b.route_id, b.bus_id, b.ending_time, b.seat_no, b.isBooked
                        FROM Bookings b
                        WHERE (b.bus_id = @bus_id AND b.seat_no = @seat_no AND b.isBooked = 1 AND b.user_id = @user_id AND b.route_id = @route_id);
                    ";
                    var result = await connection.QueryAsync<Booking>(selectQuery, queryParameters);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Booking>> InsertBookingRepoAsync(BookingQueryParameters queryParameters)
        {
            try
            {
                using (var connection = _appDbContext.Connection())
                {
                    string countQuery = @"
                        SELECT COUNT(*) FROM Bookings
                        WHERE user_id = @user_id AND bus_id = @bus_id AND route_id = @route_id;
                    ";

                    int bookingsCount = await connection.ExecuteScalarAsync<int>(countQuery, queryParameters);

                    if (bookingsCount < 4)
                    {
                        string insertQuery = @"
                            INSERT INTO Bookings (user_id, route_id, bus_id, seat_no, isBooked)
                            VALUES (@user_id, @route_id, @bus_id, @seat_no, 1);
                        ";

                        await connection.ExecuteAsync(insertQuery, queryParameters);
                        return new List<Booking>();
                    }
                    else
                    {
                        throw new Exception("The user has already booked 4 seats for this bus and route combination.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
