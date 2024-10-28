using AutoMapper;
using BACK_END.Data;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class TicketRepository : ITicket
    {
        private readonly BACK_ENDContext _db;
        private readonly IMapper _mapper;

        public TicketRepository(BACK_ENDContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DTOs.Ticket.Tickets>?> GetAllTicketAsync()
        {
            var data = await _db.Ticket.Include(t => t.Images).ToListAsync();

            var map = _mapper.Map<IEnumerable<DTOs.Ticket.Tickets>>(data);

            return map;
        }

        public async Task<Ticket?> CreateTicketAsync(DTOs.Ticket.Create data)
        {
            var ticket = new Ticket()
            {
                Type = data.Type,
                Title = data.Title,
                Content = data.Content,
                Receiver = data.Receiver,
                UserId = data.UserId,
                MotelId = data.MotelId
            };
            var result = await _db.Ticket.AddAsync(ticket);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Ticket?> UpdateTicketAsync(DTOs.Ticket.Update data)
        {
            var exist = await _db.Ticket.FirstOrDefaultAsync(x => x.Id == data.Id);
            if (exist != null)
            {
                if (data.Status != 0)
                {
                    exist.Status = data.Status;
                }
                else
                {
                    if (data.Receiver != null)
                    {
                        exist.Receiver = data.Receiver;
                    }
                }
                await _db.SaveChangesAsync();
            }
            return exist;
        }
    }
}
