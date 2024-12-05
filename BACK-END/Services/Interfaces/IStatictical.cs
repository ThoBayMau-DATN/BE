using BACK_END.DTOs.StaticDto;

namespace BACK_END.Services.Interfaces
{
    public interface IStatictical
    {
        Task<List<MotelWithEmptyRoomsDto>> GetMotelsWithEmptyRoomsAsync();

        Task<List<MonthlyRevenueDto>> GetLastSixMonthsRevenueAsync();

        //Task<List<Bill>> GetAllAsync();





        //Doanh thu admin
        Task<List<RevenueAdmin>> MonthlyRevenue(selecRevenueAdmin item);

        //đếm số tải khoản trong hệ thống
        Task<List<MonthlyCountAccount>> CountAccount(FormCountAccount item );

    }
}
