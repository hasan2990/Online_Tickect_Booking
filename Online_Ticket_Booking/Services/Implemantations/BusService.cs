using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Online_Ticket_Booking.Models;
using Online_Ticket_Booking.Models.Responses;
using Online_Ticket_Booking.Repositories.Implemantations;
using Online_Ticket_Booking.Repositories.Interfaces;
using Online_Ticket_Booking.Services.Interfaces;
using System.Text.Json;


namespace Online_Ticket_Booking.Services.Implemantations
{
    public class BusService : IBusService
    {
        private readonly IBusRepo _busRepo;
        private readonly ILogService _ilogService;
        public BusService(IBusRepo busRepo, ILogService ilogService)
        {
            _busRepo = busRepo;
            _ilogService = ilogService;
        }
        public async Task<ResponseModel> ServiceBusUser(BusInfo use)
        {
            ResponseModel response = new ResponseModel();
            var log = new Log
            {
                ActionDate = DateTime.Now,
                ActionChanges = "Add New Bus " + use + "Successful",
                JsonPayload = JsonSerializer.Serialize(use),
                IsActive = true,
            };
            var logmsg =  await _ilogService.CreateLog(log);
            response.isSuccess = true;
            response.statusMessage = await _busRepo.BusUser(use);
            return response;
        }
    }
}
