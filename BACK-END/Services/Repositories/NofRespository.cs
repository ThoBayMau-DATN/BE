using BACK_END.Data;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class NofRespository : INoti
    {
        private readonly BACK_ENDContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public NofRespository(BACK_ENDContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<Notification> addNotificationAsync(Notification notification)
        {
            notification.Status = 0;
            await _db.AddAsync(notification);
            await _db.SaveChangesAsync();
            return notification;
        }

        public async Task<IEnumerable<Notification>> getAllNotificationAsync()
        {
            return await _db.Notification.ToListAsync();
        }

        public async Task<IEnumerable<IdentityUser>> GetUsersByRoleAsync(string roleName)
        {
            return await _userManager.GetUsersInRoleAsync(roleName);
        }
        public async Task<Notification?> SendNotificationToRolesByIdAsync(int notificationId, string roleName)
        {
            var notification = await _db.Notification.FindAsync(notificationId);
            if (notification == null)
            {
                return null;
            }

            notification.Status = 2;
            _db.Notification.Update(notification);

            var usersInRole = await GetUsersByRoleAsync(roleName);

            var userEmails = new List<User>();
            foreach (var e in usersInRole)
            {
                var users = _db.User.Where(x => x.Email == e.Email);
                if (users.Any())
                {
                    userEmails.AddRange(users); 
                }
            }
            foreach (var user in userEmails)
            {
                var userNotification = new User_Notification
                {
                    UserId = user.Id,
                    NotificationId = notification.Id,
                };
                await _db.AddAsync(userNotification);
            }
            await _db.SaveChangesAsync();

            return notification;
        }

        public async Task<Notification> updateNotificationAsync(Notification notification, int id)
        {
            var notiExist = await _db.Notification.FirstOrDefaultAsync(x => x.Id == id);
            if (notiExist == null)
            {
                return null;
            }
            notiExist.Type = notification.Type;
            notiExist.Title = notification.Title;
            notiExist.Content = notification.Content;
            notiExist.Status = 0;
            await _db.SaveChangesAsync();
            return notification;
        }
    }
}
