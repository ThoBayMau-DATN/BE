//using BACK_END.Data;
//using BACK_END.DTOs.MotelDto;
//using BACK_END.DTOs.StaticDto;
//using BACK_END.Models;
//using BACK_END.Services.Interfaces;
//using Microsoft.EntityFrameworkCore;

//namespace BACK_END.Services.Repositories
//{
//    public class StaticticalRepository : IStatictical
//    {
//        private readonly BACK_ENDContext _db;


//        public StaticticalRepository(BACK_ENDContext db)
//        {
//            _db = db;
//        }

//        public async Task<List<MotelAvailabilityDTO>> GetAvailableMotelsAsync()
//        {
//            var motels = await _db.Motel
//                .Include(m => m.Rooms)
//                .ToListAsync();
//            var availableMotels = motels
//                .Where(motel => motel.Rooms.Any(room => !_db.User.Any(u => u.RoomId == room.Id)))
//                .Select(motel => new MotelAvailabilityDTO
//                {
//                    MotelName = motel.Name,
//                    Address = motel.Address,
//                    AvailableRooms = motel.Rooms.Count(room => !_db.User.Any(u => u.RoomId == room.Id)),
//                    Status = motel.Status
//                })
//                .ToList();

//            return availableMotels;
//        }

//        public async Task<List<Invoice>> GetAllAsync()
//        {
//            return await _db.Invoice.ToListAsync(); // Lấy tất cả các hóa đơn
//        }



//        public async Task<List<MonthlyRevenueDto>> GetMonthlyRevenueLastSixMonthsAsync()
//        {
//            var currentDate = DateTime.Now;
//            var sixMonthsAgo = currentDate.AddMonths(-5); // Bắt đầu từ 5 tháng trước, vì tính cả tháng hiện tại

//            var invoices = await _db.Invoice
//                .Where(i => i.TimeCreated >= sixMonthsAgo && i.TimeCreated <= currentDate)
//                .ToListAsync();

//            // Khởi tạo danh sách để lưu doanh thu theo tháng
//            var monthlyRevenue = new List<MonthlyRevenueDto>();

//            // Tính doanh thu cho từng tháng
//            for (int i = 0; i < 6; i++)
//            {
//                var month = sixMonthsAgo.AddMonths(i);
//                var monthName = month.ToString("MMMM"); // Chỉ lấy tên tháng

//                var revenue = invoices
//                    .Where(i => i.TimeCreated.Year == month.Year && i.TimeCreated.Month == month.Month)
//                    .Sum(i => i.Water + i.Electric + i.Price + i.Other);

//                monthlyRevenue.Add(new MonthlyRevenueDto { Month = monthName, Revenue = revenue });
//            }

//            return monthlyRevenue;
//        }


//    }
//}
