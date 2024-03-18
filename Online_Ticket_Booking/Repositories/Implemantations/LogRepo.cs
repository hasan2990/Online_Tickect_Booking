using Dapper;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Data;
using Online_Ticket_Booking.Repositories.Interfaces;

namespace Online_Ticket_Booking.Repositories.Implemantations
{
    public class LogRepo : ILogRepo
    {
        private readonly AppDbContext _appDbContext;
        public LogRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<long> CreateLog(Log log)
        {
            try
            {
                using (var connection = _appDbContext.Connection())
                {
                    connection.Open();
                    var query = @"INSERT INTO log 
                                (ActionDate
                                ,ActionChanges
                                ,JsonPayload
                                ,IsActive) 
                                 VALUES 
                                 (@ActionDate
                                 ,@ActionChanges
                                 ,@JsonPayload
                                 ,@IsActive)";
                    var res = await connection.ExecuteAsync(query, log);
                    return res;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new CustomizedException("Someting Went wrong. Please Contact with Admin", 400);
            }
        }
    }
}
