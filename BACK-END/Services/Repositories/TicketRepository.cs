using AutoMapper;
using BACK_END.Data;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
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

        public async Task<DTOs.Ticket.TicketPagination?> GetAllTicketAsync(DTOs.Ticket.TicketQuery ticketQuery)
        {
            IQueryable<Ticket> data = _db.Ticket.Include(x => x.Images).OrderByDescending(x => x.CreateDate);

            if (ticketQuery.Status > 0)
            {
                data = data.Where(x => x.Status == ticketQuery.Status);
            }

            if (!string.IsNullOrEmpty(ticketQuery.Search))
            {
                data = data.Where(x => x.Title.ToLower().Contains(ticketQuery.Search.ToLower()));
            }

            var page = await PagedList<Ticket>.CreateAsync(data, ticketQuery.PageNumber, ticketQuery.PageSize);

            var paginationResult = _mapper.Map<DTOs.Ticket.TicketPagination>(page);

            return paginationResult;
        }

        public async Task<DTOs.Ticket.Infoticket?> GetTicketByIdAsync(int ticketId)
        {
            var ticket = await _db.Ticket.Include(x => x.Images).Include(x => x.User).FirstOrDefaultAsync(x => x.Id == ticketId);
            if (ticket != null)
            {
                var map = _mapper.Map<DTOs.Ticket.Infoticket>(ticket);
                return map;
            }
            return null;
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
