using BACK_END.DTOs.NotiDto;
using BACK_END.DTOs.Ticket;
using BACK_END.Models;

namespace BACK_END.Services.Interfaces
{
    public interface INoti
    {
        Task<listNotificationDto> GetAllNotiAsync(NotiQuery notiQuery);

        Task<Notification> addNotificationAsync(Notification notification);

        Task<Notification> updateNotificationAsync(Notification notification, int id);

        Task<Notification?> SendNotificationToRolesByIdAsync(int notificationId, string roleName);
        Task<User?> GetUserByEmailAsync(string email);
        Task<List<Notification>> GetSentNotificationsAsync(int userId);
        Task<IEnumerable<NotiByTypeDto>> GetNotificationsByTokenAndTypeAsync(string token, int type);

    }
}
