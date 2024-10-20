using BACK_END.Models;

namespace BACK_END.Services.MyServices
{
    public interface IRoomService
    {
        Task<List<Room>> GetAvailableRooms();
    }
}
