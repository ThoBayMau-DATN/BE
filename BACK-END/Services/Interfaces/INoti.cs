using BACK_END.Models;

namespace BACK_END.Services.Interfaces
{
    public interface INoti
    {
        Task<IEnumerable<Notification>> getAllNotificationAsync();

        Task<Notification> addNotificationAsync(Notification notification);

        Task<Notification> updateNotificationAsync(Notification notification, int id);

        Task<Notification?> SendNotificationToRolesByIdAsync(int notificationId, string roleName);
    }
}
