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
                using (var connection = _appDbContext.Connection())
                {
                    string selectQuery = @"
                        SELECT b.booking_id, b.user_id, b.route_id, b.bus_id, b.ending_time, b.seat_no, b.isBooked, b.isPaid, u.user_id, u.username, u.password, u.email, u.phone_number
                        FROM Bookings b 
                        JOIN Users u ON u.user_id = b.user_id
                        WHERE (b.bus_id = @bus_id AND b.seat_no = @seat_no AND b.isBooked = 1 AND b.user_id = @user_id AND b.route_id = @route_id );
                    ";
                    /* string selectQuery = @"
                        SELECT b.booking_id, b.user_id, b.route_id, b.bus_id, b.ending_time, b.seat_no, b.isBooked, u.user_id, u.username, u.email, u.phone_number
                        FROM Bookings b 
                        JOIN Users u ON u.user_id = b.user_id
                        WHERE (b.bus_id = @bus_id AND b.seat_no = @seat_no AND b.isBooked = 1 AND b.user_id = @user_id AND b.route_id = @route_id AND b.isPaid = 1);
                    ";*/

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
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string countQuery = @"
                                SELECT COUNT(*) FROM Bookings
                                WHERE user_id = @user_id AND bus_id = @bus_id AND route_id = @route_id And isPaid = 1;
                            ";

                            int bookingsCount = await connection.ExecuteScalarAsync<int>(countQuery, queryParameters, transaction);

                            if (bookingsCount < 4)
                            {
                                string insertQuery = @"
                                    INSERT INTO Bookings (user_id, route_id, bus_id, ending_time, seat_no, isBooked, isPaid)
                                    VALUES (@user_id, @route_id, @bus_id,Getdate(), @seat_no, 1, @isPaid);
                                ";

                                await connection.ExecuteAsync(insertQuery, queryParameters, transaction);

                                transaction.Commit();

                                return new List<Booking>();
                            }
                            else
                            {
                                throw new Exception("The user has already booked 4 seats for this bus and route combination.");
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception(ex.Message);
                        }
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


