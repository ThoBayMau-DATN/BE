using BACK_END.Data;
using BACK_END.DTOs.StaticDto;
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

        //public async Task<List<Invoice>> GetAllAsync()
        //{
        //    return await _db.Invoice.ToListAsync(); // Lấy tất cả các hóa đơn
        //}

        public async Task<List<MonthlyRevenueDto>> GetLastSixMonthsRevenueAsync()
        {
            var sixMonthsAgo = DateTime.Now.AddMonths(-5);

            var monthlyRevenue = await _db.Bill
                .Where(bill => bill.CreateDate >= sixMonthsAgo)
                .GroupBy(bill => new { bill.CreateDate.Year, bill.CreateDate.Month })
                .Select(g => new MonthlyRevenueDto
                {
                    Month = g.Key.Month.ToString(),
                    Year = g.Key.Year,
                    Revenue = g.Sum(bill => bill.Total)
                })
                .ToListAsync();
            var sortedMonthlyRevenue = monthlyRevenue
                .OrderBy(dto => dto.Year)
                .ThenBy(dto => int.Parse(dto.Month))
                .ToList();
            foreach (var item in sortedMonthlyRevenue)
            {
                item.Month = $"Tháng {item.Month}/{item.Year}";
            }
            return sortedMonthlyRevenue;
        }

        public async Task<List<MotelWithEmptyRoomsDto>> GetMotelsWithEmptyRoomsAsync()
        {
            var motelsWithEmptyRooms = await _db.Motel
                .Select(motel => new MotelWithEmptyRoomsDto
                {
                    Name = motel.Name,
                    Address = motel.Address,
                    Status = motel.Status,
                    EmptyRoomsCount = _db.Room
                        .Where(room => room.Room_Type.MotelId == motel.Id && room.Status == 0)
                        .Count(room =>
                            !_db.Room_History.Any(history => history.RoomId == room.Id) ||
                            _db.Room_History
                                .Where(history => history.RoomId == room.Id)
                                .All(h => h.EndDate != null)
                        )
                })
                .Where(m => m.EmptyRoomsCount > 0)
                .ToListAsync();

            return motelsWithEmptyRooms;
        }
    }
}
