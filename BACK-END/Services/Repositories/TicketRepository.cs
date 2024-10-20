using BACK_END.Data;
using BACK_END.DTOs.Ticket;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class TicketRepository : ITicket
    {
        private readonly BACK_ENDContext _db;

        public TicketRepository(BACK_ENDContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Ticket>?> GetAllTicketAsync()
        {
            return await _db.Ticket.ToListAsync();
        }

        public async Task<Ticket?> CreateTicketAsync(Create data)
        {
            var ticket = new Ticket()
            {
                Type = data.Type,
                Title = data.Title,
                Content = data.Content,
                Status = 0,
                UserId = data.UserId,
                MotelId = data.MotelId
            };
            var result = await _db.Ticket.AddAsync(ticket);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Ticket?> UpdateTicketAsync(Update data)
        {
            var exist = await _db.Ticket.FirstOrDefaultAsync(x => x.Id == data.Id);
            if (exist != null)
            {
                if (exist.Status != 0)
                {
                    exist.Status = data.Status;
                }
                else
                {
                    exist.Receiver = data.Receiver;
                }
                await _db.SaveChangesAsync();
            }
            return exist;
        }
    }
}
