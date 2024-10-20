using BACK_END.Data;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

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

        //public async Task<Notification> addNotificationAsync(Notification notification)
        //{
        //    await _db.AddAsync(notification);
        //    await _db.SaveChangesAsync();
        //    return notification;
        //}

        //public async Task<IEnumerable<Notification>> getAllNotificationAsync()
        //{
        //    return await _db.Notification.ToListAsync();
        //}

        //public async Task<IEnumerable<IdentityUser>> GetUsersByRoleAsync(string roleName)
        //{
        //    return await _userManager.GetUsersInRoleAsync(roleName);
        //}
        //public async Task<Notification> SendNotificationToRolesAsync(string roleName, Notification notification)
        //{
        //    // Lấy danh sách tất cả người dùng trong các vai trò được chỉ định
        //    var usersInRole = await GetUsersByRoleAsync(roleName);

        //    var userEmails = new List<User>();
        //    foreach (var e in usersInRole)
        //    {
        //        var users =  _db.User.Where(x => x.Email == e.Email);
        //        if (users.Any())
        //        {
        //            userEmails.AddRange(users);  // Thêm tất cả user vào danh sách
        //        }


        //    }
        //    foreach (var user in userEmails)
        //    {
        //        // Tạo thông báo cho từng người dùng
        //        var userNotification = new Notification
        //        {
        //            UserId = user.Id,
        //            Title = notification.Title,
        //            Content = notification.Content,
        //            Status = 1,
        //            Type = notification.Type
        //        };
        //        await _db.AddAsync(userNotification);
        //    }
        //    await _db.SaveChangesAsync();

        //    return notification;
        //}

        //public async Task<Notification> updateNotificationAsync(Notification notification, int id)
        //{
        //    var notiExist = await _db.Notification.FirstOrDefaultAsync(x => x.Id == id);
        //    if (notiExist == null)
        //    {
        //        return null;
        //    }
        //    notiExist.Type = notification.Type;
        //    notiExist.Title = notification.Title;
        //    notiExist.Content = notification.Content;
        //    notiExist.Status = notification.Status;
        //    notiExist.UserId = notification.UserId;
        //    await _db.SaveChangesAsync();
        //    return notification;
        //}
    }
}
