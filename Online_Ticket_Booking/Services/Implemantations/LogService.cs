using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;

namespace Online_Ticket_Booking.Services.Implemantations
{
    public class LogService : ILogService
    {
        private readonly ILogRepo _logRepo;
        public LogService(ILogRepo logRepo)
        {
            _logRepo = logRepo;
        }
        public async Task<ResponseModel> CreateLog(Log log)
        {
            try
            {
                var res = await _logRepo.CreateLog(log);
                var response = new ResponseModel();

                if (res != 0)
                {
                    response.isSuccess = true;
                    response.statusMessage = "Log Successfully Created";
                }
                else
                {
                    response.isSuccess = false;
                    response.statusMessage = "Unsuccessful to Create Log";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
