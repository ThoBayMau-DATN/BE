using BACK_END.Data;
using BACK_END.DTOs.StaticDto;
using BACK_END.DTOs.UserDto;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BACK_END.Services.Repositories
{
    public class StaticticalRepository : IStatictical
    {
        private readonly BACK_ENDContext _db;
        private readonly IAuth _auth;
        private readonly UserManager<IdentityUser> _userManager;


        public StaticticalRepository(BACK_ENDContext db, IAuth auth, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _auth = auth;
            _userManager = userManager;
        }

        

        //public async Task<List<Invoice>> GetAllAsync()
        //{
        //    return await _db.Invoice.ToListAsync(); // Lấy tất cả các hóa đơn
        //}

        public async Task<List<MonthlyRevenueDto>> GetLastSixMonthsRevenueAsync()
        {
            var sixMonthsAgo = DateTime.Now.AddMonths(-5);

            var monthlyRevenue = await _db.Bill
                .Where(bill => bill.CreatedDate >= sixMonthsAgo)
                .GroupBy(bill => new { bill.CreatedDate.Year, bill.CreatedDate.Month })
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


        //doanh thu admin
        public async Task<List<RevenueAdmin>> MonthlyRevenue(selecRevenueAdmin item)
        {
            //check token
            try
            {
                if( item.token != null){

                    var isUser = await _auth.GetUserByToken(item.token);

                    if (isUser.Role.ToUpper() == "ADMIN")
                    {
                        var currentDate = DateTime.Now;
                        //thống kê doanh thu
                        var monthlyRevenue = await _db.Package_User
                            .Where(x => x.CreateDate.HasValue
                          )
                            .Join(_db.Package, pu => pu.PackageId, p => p.Id, (pu, p) => new { pu, p })
                            .GroupBy(x => new { x.pu.CreateDate.Value.Month, x.pu.CreateDate.Value.Year })
                            .Select(x => new RevenueAdmin
                            {
                                Month = x.Key.Month,
                                Year = x.Key.Year,
                                TotalRevenue  = x.Sum(x => x.p.Price)
                            }).ToListAsync();

                        return monthlyRevenue;



                    }
                    else
                    {
                        return null;
                    }
                }
               
            }
            catch(UnauthorizedAccessException ex)
            {
                throw new Exception("Không có quyền truy cập.", ex);
            }

            return null;
        }
        //count Account
        public async Task<List<MonthlyCountAccount>> CountAccount(FormCountAccount item)
        {
            try
            {
                if (item.token != null) {
                    var isUser = await _auth.GetUserByToken(item.token);
                    if (isUser.Role.ToUpper() == "ADMIN")
                    {
                        //lấy danh sách người dùng
                        var users = await _db.User.ToListAsync();
                        //Truy vấn danh sách người dùng bảng ASP


                        Dictionary<string, string> userRoles = new Dictionary<string, string>();

                        IList<IdentityUser> iusers = await _userManager.Users.ToListAsync(); // tất cả người dùng trong identity
                        for (int i = 0; i < iusers.Count; i++)
                        {
                            var roles = await _userManager.GetRolesAsync(iusers[i]);
                            for (int j = 0; j < roles.Count; j++)
                            {
                                Console.WriteLine(roles[j]);
                                userRoles.Add(iusers[i].Email, roles[0]);
                            }
                        }
                        // danh sách TẤt CẢ các người dùng trong identity
                        Dictionary<string, User> userDict = new Dictionary<string, User>();
                        foreach (User user in _db.User.AsQueryable())
                        {
                            userDict.Add(user.Email, user);
                            Console.WriteLine("Email người dùng: " + user.Email);
                        }

                        var usersWithRoles = users.Select(user => new GetAllUserRepositoryDto
                        {
                            Id = userDict[user.Email].Id,
                            Email = user.Email,
                            FullName = userDict[user.Email].FullName,
                            Phone = userDict[user.Email].Phone,
                            Avatar = userDict[user.Email].Avatar,
                            TimeCreated = userDict[user.Email].CreateDate,
                            Status = userDict[user.Email].Status,
                            Role = userRoles.GetValueOrDefault(user.Email, "")
                        });



                        if (!string.IsNullOrEmpty(item.role))
                        {
                            usersWithRoles = usersWithRoles.Where(x => x.Role.ToUpper() == item.role.ToUpper());
                        }
                        var monthlyCounts = usersWithRoles
                       .GroupBy(x => new { x.TimeCreated.Year, x.TimeCreated.Month })
                       .Select(g => new MonthlyCountAccount
                       {
                           Year = g.Key.Year,
                           Month = g.Key.Month,
                           TotalAccount = g.Count()
                       })
                       .OrderBy(x => x.Year)
                       .ThenBy(x => x.Month)
                       .ToList();

                        return monthlyCounts;
                    }
                }
                else
                {

                }

            }
            catch
            {

            }
            throw new NotImplementedException();
        }
    }
}
