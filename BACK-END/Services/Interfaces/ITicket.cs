using BACK_END.Models;

namespace BACK_END.Services.Interfaces
{
    public interface ITicket
    {
        Task<IEnumerable<DTOs.Ticket.Tickets>?> GetAllTicketAsync();
        Task<Ticket?> CreateTicketAsync(DTOs.Ticket.Create data);
        Task<Ticket?> UpdateTicketAsync(DTOs.Ticket.Update data);
    }
}
