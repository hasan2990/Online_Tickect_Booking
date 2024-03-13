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
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string countQuery = @"
                                SELECT COUNT(*) FROM Bookings
                                WHERE user_id = @user_id AND bus_id = @bus_id AND route_id = @route_id;
                            ";

                            int bookingsCount = await connection.ExecuteScalarAsync<int>(countQuery, queryParameters, transaction);

                            if (bookingsCount < 4)
                            {
                                /* int totalAmount = bookingsCount * 50;
                                 bool paymentSuccessful = ProcessPayment(paymentInfo, totalAmount);
                                 if (paymentSuccessful)
                                 {*/
                                string insertQuery = @"
                                    INSERT INTO Bookings (user_id, route_id, bus_id, seat_no, isBooked)
                                    VALUES (@user_id, @route_id, @bus_id, @seat_no, 1);
                                ";

                                await connection.ExecuteAsync(insertQuery, queryParameters, transaction);

                                transaction.Commit();

                                return new List<Booking>();
                                /* }
                                 else
                                 {
                                     throw new Exception("Payment failed. Please try again.");
                                 }*/
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

        /*private bool ProcessPayment(object paymentInfo, int totalAmount)
        {
            throw new NotImplementedException();
        }

        public bool ProcessPayment(PaymentInfo paymentInfo)
        {
            try
            {
                switch (paymentInfo.PaymentMethod)
                {
                    case (int)PaymentMethod.bKash:
                        if (!string.IsNullOrWhiteSpace(paymentInfo.bKashPhoneNumber))
                        {
                            Console.WriteLine($"Payment of {paymentInfo.Amount} {paymentInfo.Currency} via bKash is successful.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("bKash phone number is missing or invalid.");
                            return false;
                        }

                    case (int)PaymentMethod.Nagad:
                        if (!string.IsNullOrWhiteSpace(paymentInfo.NagadAccountNumber))
                        {
                            Console.WriteLine($"Payment of {paymentInfo.Amount} {paymentInfo.Currency} via Nagad is successful.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Nagad account number is missing or invalid.");
                            return false;
                        }

                    case (int)PaymentMethod.Card:
                        if (!string.IsNullOrWhiteSpace(paymentInfo.CardNumber) &&
                            !string.IsNullOrWhiteSpace(paymentInfo.CardHolderName) &&
                            !string.IsNullOrWhiteSpace(paymentInfo.CardExpirationDate) &&
                            !string.IsNullOrWhiteSpace(paymentInfo.CardCVV))
                        {
                            Console.WriteLine($"Payment of {paymentInfo.Amount} {paymentInfo.Currency} via Card is successful.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Card information is incomplete or invalid.");
                            return false;
                        }

                    default:
                        Console.WriteLine("Unsupported payment method.");
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing payment: " + ex.Message);
                return false;
            }
        }*/
    }
}


