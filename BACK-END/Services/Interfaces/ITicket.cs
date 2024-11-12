using BACK_END.Models;

namespace BACK_END.Services.Interfaces
{
    public interface ITicket
    {
        Task<DTOs.Ticket.TicketPagination?> GetAllTicketByRoleAsync(DTOs.Ticket.TicketQuery ticketQuery);
        Task<DTOs.Ticket.Infoticket?> GetTicketByIdAsync(DTOs.Ticket.InfoticketQuery infoticketQuery);
        Task<IEnumerable<DTOs.Ticket.Receiver>?> GetReceiverAsync(string? roleName);
        Task<DTOs.Ticket.Tickets?> CreateTicketAsync(DTOs.Ticket.Create data);
        Task<Ticket?> UpdateTicketAsync(DTOs.Ticket.Update data);
    }
}
