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
            await _db.AddAsync(notification);
            await _db.SaveChangesAsync();
            return notification;
        }

        public async Task<IEnumerable<Notification>> getAllNotificationAsync()
        {
            return await _db.Notification.ToListAsync();
        }

        public async Task<Notification> SendNotificationToRolesAsync(List<string> roles, Notification notification)
        {
            // Lấy danh sách tất cả người dùng trong các vai trò được chỉ định
            var usersInRoles = new List<IdentityUser>();
            foreach (var role in roles)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role);
                usersInRoles.AddRange(usersInRole);
            }

            // Tạo thông báo cho từng người dùng
            foreach (var user in usersInRoles.Distinct())
            {
                var newNotification = new Notification
                {
                    Type = notification.Type,
                    Title = notification.Title,
                    Content = notification.Content,
                    Status = 1, // Ví dụ: 1 = đã gửi
                    UserId = Convert.ToInt32(user.Id)
                };
                await _db.AddAsync(newNotification);
            }

            // Lưu tất cả thay đổi vào DB
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
            notiExist.Status = notification.Status;
            notiExist.UserId = notification.UserId;
            await _db.SaveChangesAsync();
            return notification;
        }
    }
}
