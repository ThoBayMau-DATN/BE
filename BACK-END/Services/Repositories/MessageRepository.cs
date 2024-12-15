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

        public async Task<IEnumerable<DTOs.ChatDTO.MessageDTO>?> getMessageHistoryAsync(int SenderId, int ReceiverId)
        {
            var data = await _db.Message
                .Where(x => (x.SenderId == SenderId && x.ReceiverId == ReceiverId) || (x.SenderId == ReceiverId && x.ReceiverId == SenderId))
                .OrderBy(x => x.Time)
                .ToListAsync();
            var map = _mapper.Map<List<DTOs.ChatDTO.MessageDTO>>(data);
            return map;
        }
    }
}
