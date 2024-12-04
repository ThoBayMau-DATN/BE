using AutoMapper;
using BACK_END.Data;
using BACK_END.DTOs.NotiDto;
using BACK_END.DTOs.Ticket;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

namespace BACK_END.Services.Repositories
{
    public class NofRespository : INoti
    {
        private readonly BACK_ENDContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public NofRespository(BACK_ENDContext db, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _db = db;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Notification> addNotificationAsync(Notification notification)
        {
            notification.Status = false;
            await _db.AddAsync(notification);
            await _db.SaveChangesAsync();
            return notification;
        }

        public async Task<listNotificationDto> GetAllNotiAsync(NotiQuery notiQuery)
        {
            IQueryable<Notification> data = _db.Notification;

            if (notiQuery.Status)
            {
                data = data.Where(x => x.Status == notiQuery.Status);
            }
            if (!string.IsNullOrEmpty(notiQuery.Search))
            {
                data = data.Where(x => x.Title.ToLower().Contains(notiQuery.Search.ToLower()));
            }

            var page = await PagedList<Notification>.CreateAsync(data, notiQuery.PageNumber, notiQuery.PageSize);

            var paginationResult = _mapper.Map<listNotificationDto>(page);
            return paginationResult;
        }

        public async Task<IEnumerable<NotiByTypeDto>> GetNotificationsByTokenAndTypeAsync(string token, int type)
        {
            var email = HandlerToken(token);
            if (string.IsNullOrEmpty(email))
                return null;
            var user = await _db.User.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return null;
            var notifications = await _db.User_Notification
                .Include(un => un.Notification)
                .Where(un => un.UserId == user.Id && un.Notification != null && un.Notification.Type == type)
                .Select(un => new NotiByTypeDto
                {
                    Id = un.Notification.Id,
                    Type = un.Notification.Type,
                    Title = un.Notification.Title,
                    Content = un.Notification.Content,
                    Sender = un.Notification.Sender,
                    CreateDate = un.Notification.CreateDate
                })
                .ToListAsync();

            return notifications;
        }

        public async Task<List<Notification>> GetSentNotificationsAsync(int userId)
        {
            return await _db.User_Notification
                .Where(un => un.UserId == userId && un.Notification!.Status == true)
                .Include(un => un.Notification)
                .Select(un => un.Notification)
                .ToListAsync();
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _db.User.FirstOrDefaultAsync(u => u.Email == email);
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

            notification.Status = true;
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
            notiExist.Status = false;
            await _db.SaveChangesAsync();
            return notification;
        }

        private string? HandlerToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                return jwtToken.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token error: {ex.Message}");
                return null;
            }
        }
    }
}
