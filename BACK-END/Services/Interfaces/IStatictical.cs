using BACK_END.Models;

namespace BACK_END.Services.Interfaces
{
    public interface IStatictical
    {
        Task<int> GetRoomCountUnderOneMillionAsync();

        Task<int> GetNewUserCountByTimeCreate();

        Task<int> GetMonthlyRentalCountAsync();

        Task<List<Motel>> GetAvailableMotelsAsync();

        Task<List<Invoice>> GetInvoicesLastSixMonthsAsync();
    }
}
