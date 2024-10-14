using BACK_END.Data;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class NofRespository : INoti
    {
        private readonly BACK_ENDContext _db;

        public NofRespository(BACK_ENDContext db)
        {
            _db = db;
        }

        public async Task<Notification> addNotificationAsync(Notification notification)
        {
            await _db.AddAsync(notification);
            await _db.SaveChangesAsync();
            return notification;
        }

        public async Task<IEnumerable<Notification>> getAllNotificationAsync()
        {
            return await _db.Notification.ToListAsync();
        }

        

        

    }
}
