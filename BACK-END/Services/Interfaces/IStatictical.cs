namespace BACK_END.Services.Interfaces
{
    public interface IStatictical
    {
        Task<int> GetRoomCountUnderOneMillionAsync();

        Task<int> GetNewUserCountByTimeCreate();

        Task<int> GetMonthlyRentalCountAsync();
    }
}
