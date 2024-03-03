using Dapper;
using Online_Ticket_Booking.Models;
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

        public string RegisterUser(RegistrationModel registration)
        {
            string query = "INSERT INTO Registration (UserName, Password, Email, IsActive) VALUES (@UserName, @Password, @Email, @IsActive)";

            int rowsAffected = 0;
            using (var connection = this._appDbContext.Connection())
            {

                rowsAffected = connection.Execute(query, registration);

                if (rowsAffected > 0)
                {
                    return "Data Inserted";
                }
                else
                {
                    return "Error";
                }
            }
        }
    }
}
