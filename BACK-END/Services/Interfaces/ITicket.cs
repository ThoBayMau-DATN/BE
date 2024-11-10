using BACK_END.Models;

namespace BACK_END.Services.Interfaces
{
    public interface ITicket
    {
        Task<DTOs.Ticket.TicketPagination> GetAllTicketAsync(DTOs.Ticket.TicketQuery ticketQuery);
        Task<DTOs.Ticket.Infoticket?> GetTicketByIdAsync(int ticketId);
        Task<IEnumerable<DTOs.Ticket.Receiver>?> GetReceiverAsync(string? roleName);
        Task<DTOs.Ticket.Tickets?> CreateTicketAsync(DTOs.Ticket.Create data);
        Task<Ticket?> UpdateTicketAsync(DTOs.Ticket.Update data);
    }
}
