using BACK_END.DTOs.StaticDto;

namespace BACK_END.Services.Interfaces
{
    public interface IStatictical
    {
        Task<List<MotelWithEmptyRoomsDto>> GetMotelsWithEmptyRoomsAsync();

        //Task<List<MonthlyRevenueDto>> GetMonthlyRevenueLastSixMonthsAsync();

        //Task<List<Bill>> GetAllAsync();
    }
}
