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



        //public async Task<List<MonthlyRevenueDto>> GetMonthlyRevenueLastSixMonthsAsync()
        //{
        //    var currentDate = DateTime.Now;
        //    var sixMonthsAgo = currentDate.AddMonths(-5); // Bắt đầu từ 5 tháng trước, vì tính cả tháng hiện tại

        //    var invoices = await _db.Invoice
        //        .Where(i => i.TimeCreated >= sixMonthsAgo && i.TimeCreated <= currentDate)
        //        .ToListAsync();

        //     Khởi tạo danh sách để lưu doanh thu theo tháng
        //    var monthlyRevenue = new List<MonthlyRevenueDto>();

        //     Tính doanh thu cho từng tháng
        //    for (int i = 0; i < 6; i++)
        //    {
        //        var month = sixMonthsAgo.AddMonths(i);
        //        var monthName = month.ToString("MMMM"); // Chỉ lấy tên tháng

        //        var revenue = invoices
        //            .Where(i => i.TimeCreated.Year == month.Year && i.TimeCreated.Month == month.Month)
        //            .Sum(i => i.Water + i.Electric + i.Price + i.Other);

        //        monthlyRevenue.Add(new MonthlyRevenueDto { Month = monthName, Revenue = revenue });
        //    }

        //    return monthlyRevenue;
        //}

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
