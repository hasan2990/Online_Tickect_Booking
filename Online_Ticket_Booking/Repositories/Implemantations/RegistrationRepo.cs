using Dapper;
using Online_Ticket_Booking.Models.Authentication;
using Online_Ticket_Booking.Models.Data;
using Online_Ticket_Booking.Repositories.Interfaces;

namespace Online_Ticket_Booking.Repositories.Implemantations
{
    public class RegistrationRepo:IRegistrationRepo
    {
        private readonly AppDbContext _appDbContext;

        public RegistrationRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<string> RegisterUser(User registration)
        {
            string query = @"INSERT INTO Users (username, password, email, IsActive,phone_number) VALUES (@username, @password, @email, @IsActive, @phone_number)";

            int rowsAffected = 0;
            using (var connection = this._appDbContext.Connection())
            {

                rowsAffected = await connection.ExecuteAsync(query, registration);

                if (rowsAffected > 0)
                {
                    return "Registration Complete";
                }
                else
                {
                    return "Error";
                }
            }
        }
    }
}
