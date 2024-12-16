using AutoMapper;
using BACK_END.Data;
using BACK_END.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class MessageRepository : IMessage
    {
        private readonly BACK_ENDContext _db;
        private readonly IMapper _mapper;

        public MessageRepository(BACK_ENDContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<DTOs.ChatDTO.MessageDTO>? createMessageAsync(DTOs.ChatDTO.MessageDTO data)
        {
            if ((data.SenderId != null && data.SenderId != 0) || (data.ReceiverId != null && data.ReceiverId != 0))
            {
                var message = new Models.Message()
                {
                    Content = data.Content,
                    Time = DateTime.Now,
                    SenderId = data.SenderId,
                    ReceiverId = data.ReceiverId
                };
                await _db.Message.AddAsync(message);
                await _db.SaveChangesAsync();
                var map = _mapper.Map<DTOs.ChatDTO.MessageDTO>(message);
                return map;
            }
            return null;
        }

        public async Task<IEnumerable<DTOs.ChatDTO.ReceiverDTO>?> getListUserAsync(int userId)
        {
            var messages = await _db.Message
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .ToListAsync();

            var latestMessages = messages
                .GroupBy(m => m.SenderId == userId ? m.ReceiverId : m.SenderId)
                .Select(g => g.OrderByDescending(m => m.Time).FirstOrDefault())
                .ToList();

            var result = _mapper.Map<List<DTOs.ChatDTO.ReceiverDTO>>(latestMessages, opt =>
            {
                opt.Items["UserId"] = userId;
            });

            return result;
        }

        public async Task<IEnumerable<DTOs.ChatDTO.MessageDTO>?> getMessageHistoryAsync(int SenderId, int ReceiverId)
        {
            var data = await _db.Message
                .Where(x => (x.SenderId == SenderId && x.ReceiverId == ReceiverId) || (x.SenderId == ReceiverId && x.ReceiverId == SenderId))
                .OrderBy(x => x.Time)
                .ToListAsync();
            var map = _mapper.Map<List<DTOs.ChatDTO.MessageDTO>>(data);
            return map;
        }

        public async Task<IEnumerable<DTOs.ChatDTO.SearchDTO>?> getSearchAsync(string key, int userId)
        {
            var data = await _db.User.Where(x => x.Phone.Contains(key) && x.Id != userId).ToListAsync();
            var map = _mapper.Map<List<DTOs.ChatDTO.SearchDTO>>(data);
            return map;
        }
    }
}
