using BACK_END.Data;
using BACK_END.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class StaticticalRepository : IStatictical
    {
        private readonly BACK_ENDContext _db;

        public StaticticalRepository(BACK_ENDContext db)
        {
            _db = db;
        }

        public async Task<int> GetMonthlyRentalCountAsync()
        {
            var now = DateTime.Now;
            var firstDayOfMonth = new DateTime(now.Year, now.Month, 1);

            var rentalCount = await _db.Rental.CountAsync(r => r.TimeStart >= firstDayOfMonth);
            return rentalCount;
        }

        public async Task<int> GetNewUserCountByTimeCreate()
        {
            var oneMonthAgo = DateTime.Now.AddMonths(-1);
            var getNU = await _db.User.CountAsync(r => r.TimeCreated >= oneMonthAgo);
            return getNU;
        }

        public async Task<int> GetRoomCountUnderOneMillionAsync()
        {
            var statictical = await _db.Room
        .CountAsync(r => r.Price < 1000000);
            return statictical;
        }
    }
}
