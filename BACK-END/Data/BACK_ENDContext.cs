using BACK_END.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Data
{
    public class BACK_ENDContext : IdentityDbContext<IdentityUser>
    {
        public BACK_ENDContext(DbContextOptions<BACK_ENDContext> options)
            : base(options)
        {
        }

        public DbSet<Room> Room { get; set; }
        public DbSet<Consumption> Consumption { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Motel> Motel { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Rental> Rental { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Term> Term { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Term>().HasData(
                new Term { Id = 1002, Link = "https://example.com/link2" },
                new Term { Id = 1001, Link = "https://example.com/link3" }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1001,
                    FullName = "Nguyễn Văn A",
                    Phone = "0901234567",
                    Email = "vana@example.com",
                    Avatar = "avatar1.png",
                    TimeCreated = DateTime.Now,
                    Status = true
                },
                new User
                {
                    Id = 1002,
                    FullName = "Trần Thị B",
                    Phone = "0902345678",
                    Email = "thib@example.com",
                    Avatar = "avatar2.png",
                    TimeCreated = DateTime.Now,
                    Status = true
                },
                new User
                {
                    Id = 1003,
                    FullName = "Lê Văn C",
                    Phone = "0903456789",
                    Email = "vanc@example.com",
                    Avatar = "avatar3.png",
                    TimeCreated = DateTime.Now,
                    Status = true
                }

            );

            modelBuilder.Entity<Motel>().HasData(
                new Motel
                {
                    Id = 1001,
                    Name = "Tro A",
                    Address = "123 Đường Biển, Quận 1, TP. HCM",
                    Location = "10.762622, 106.660172",
                    TotalRoom = 20,
                    Status = 1, // Đang hoạt động
                    UserId = 1001,
                    TermId = 1001
                },
                new Motel
                {
                    Id = 1002,
                    Name = "Tro B",
                    Address = "456 Đường Sông, Quận 2, TP. HCM",
                    Location = "10.762623, 106.660173",
                    TotalRoom = 15,
                    Status = 0, // Tạm ngừng
                    UserId = 1002,
                    TermId = 1002
                },
                new Motel
                {
                    Id = 1003,
                    Name = "Tro C",
                    Address = "789 Đường Núi, Quận 3, TP. HCM",
                    Location = "10.762624, 106.660174",
                    TotalRoom = 30,
                    Status = 1, // Đang hoạt động
                    UserId = 1003,
                    TermId = 1001
                },
                new Motel
                {
                    Id = 1004,
                    Name = "Tro D",
                    Address = "101 Đường Biển, Quận 4, TP. HCM",
                    Location = "10.762625, 106.660175",
                    TotalRoom = 18,
                    Status = 1,
                    UserId = 1001,
                    TermId = 1002
                },
                new Motel
                {
                    Id = 1005,
                    Name = "Tro E",
                    Address = "202 Đường Mặt Trăng, Quận 5, TP. HCM",
                    Location = "10.762626, 106.660176",
                    TotalRoom = 12,
                    Status = 0,
                    UserId = 1002,
                    TermId = 1001
                },
                new Motel
                {
                    Id = 1006,
                    Name = "Tro f",
                    Address = "303 Đường Bình Yên, Quận 6, TP. HCM",
                    Location = "10.762627, 106.660177",
                    TotalRoom = 25,
                    Status = 1,
                    UserId = 1003,
                    TermId = 1002
                },
                new Motel
                {
                    Id = 1007,
                    Name = "Tro g",
                    Address = "404 Đường Hồng Hà, Quận 7, TP. HCM",
                    Location = "10.762628, 106.660178",
                    TotalRoom = 16,
                    Status = 1,
                    UserId = 1001,
                    TermId = 1001
                },
                new Motel
                {
                    Id = 1008,
                    Name = "Tro H",
                    Address = "505 Đường Biển Xanh, Quận 8, TP. HCM",
                    Location = "10.762629, 106.660179",
                    TotalRoom = 20,
                    Status = 0,
                    UserId = 1002,
                    TermId = 1002
                },
                new Motel
                {
                    Id = 1009,
                    Name = "Tro I",
                    Address = "606 Đường Núi Ngàn, Quận 9, TP. HCM",
                    Location = "10.762630, 106.660180",
                    TotalRoom = 22,
                    Status = 1,
                    UserId = 1003,
                    TermId = 1001
                },
                new Motel
                {
                    Id = 1010,
                    Name = "Tro j",
                    Address = "707 Đường An Bình, Quận 10, TP. HCM",
                    Location = "10.762631, 106.660181",
                    TotalRoom = 30,
                    Status = 1,
                    UserId = 1001,
                    TermId = 1002
                }
            );

            modelBuilder.Entity<Price>().HasData(
                new Price
                {
                    Id = 1001,
                    Water = 5000.50,
                    Electric = 3000.75,
                    Other = 1000.20,
                    IsActive = true,
                    MotelId = 1001
                },
                new Price
                {
                    Id = 1002,
                    Water = 6000.25,
                    Electric = 3500.50,
                    Other = 1500.30,
                    IsActive = true,
                    MotelId = 1002
                },
                new Price
                {
                    Id = 1003,
                    Water = 5500.00,
                    Electric = 3200.00,
                    Other = 1200.00,
                    IsActive = false,
                    MotelId = 1003
                },
                new Price
                {
                    Id = 1004,
                    Water = 6200.10,
                    Electric = 3400.55,
                    Other = 1300.15,
                    IsActive = true,
                    MotelId = 1004
                },
                new Price
                {
                    Id = 1005,
                    Water = 5800.75,
                    Electric = 3100.85,
                    Other = 1400.45,
                    IsActive = false,
                    MotelId = 1005
                },
                new Price
                {
                    Id = 1006,
                    Water = 6100.65,
                    Electric = 3600.95,
                    Other = 1600.35,
                    IsActive = true,
                    MotelId = 1006
                },
                new Price
                {
                    Id = 1007,
                    Water = 5700.20,
                    Electric = 3300.70,
                    Other = 1100.80,
                    IsActive = true,
                    MotelId = 1007
                },
                new Price
                {
                    Id = 1008,
                    Water = 5900.40,
                    Electric = 3400.30,
                    Other = 1700.50,
                    IsActive = false,
                    MotelId = 1008
                },
                new Price
                {
                    Id = 1009,
                    Water = 5600.10,
                    Electric = 3200.60,
                    Other = 1800.25,
                    IsActive = true,
                    MotelId = 1009
                },
                new Price
                {
                    Id = 1010,
                    Water = 6000.80,
                    Electric = 3500.20,
                    Other = 1900.55,
                    IsActive = true,
                    MotelId = 1010
                }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1001,
                    RoomNumber = 101,
                    Area = 25,
                    Price = 500000,
                    Status = 1, // Đang hoạt động
                    MotelId = 1001
                },
                new Room
                {
                    Id = 1002,
                    RoomNumber = 102,
                    Area = 30,
                    Price = 600000,
                    Status = 0, // Tạm ngừng
                    MotelId = 1002
                },
                new Room
                {
                    Id = 1003,
                    RoomNumber = 103,
                    Area = 35,
                    Price = 700000,
                    Status = 1,
                    MotelId = 1003
                },
                new Room
                {
                    Id = 1004,
                    RoomNumber = 104,
                    Area = 40,
                    Price = 800000,
                    Status = 1,
                    MotelId = 1004
                },
                new Room
                {
                    Id = 1005,
                    RoomNumber = 105,
                    Area = 45,
                    Price = 900000,
                    Status = 0,
                    MotelId = 1005
                },
                new Room
                {
                    Id = 1006,
                    RoomNumber = 106,
                    Area = 50,
                    Price = 1000000,
                    Status = 1,
                    MotelId = 1006
                },
                new Room
                {
                    Id = 1007,
                    RoomNumber = 107,
                    Area = 55,
                    Price = 1100000,
                    Status = 1,
                    MotelId = 1007
                },
                new Room
                {
                    Id = 1008,
                    RoomNumber = 108,
                    Area = 60,
                    Price = 1200000,
                    Status = 0,
                    MotelId = 1008
                },
                new Room
                {
                    Id = 1009,
                    RoomNumber = 109,
                    Area = 65,
                    Price = 1300000,
                    Status = 1,
                    MotelId = 1009
                },
                new Room
                {
                    Id = 1010,
                    RoomNumber = 110,
                    Area = 70,
                    Price = 1400000,
                    Status = 1,
                    MotelId = 1010
                }
            );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket
                {
                    Id = 1001,
                    Type = "Yêu cầu sửa chữa",
                    Title = "Hệ thống nước gặp sự cố",
                    Content = "Phòng 101 gặp vấn đề với hệ thống nước.",
                    Status = 1, // Đang xử lý
                    UserId = 1001,
                    MotelId = 1001
                },
                new Ticket
                {
                    Id = 1002,
                    Type = "Khiếu nại",
                    Title = "Chất lượng dịch vụ kém",
                    Content = "Khách hàng phàn nàn về dịch vụ phòng 102.",
                    Status = 0, // Chưa xử lý
                    UserId = 1002,
                    MotelId = 1002
                },
                new Ticket
                {
                    Id = 1003,
                    Type = "Yêu cầu bảo trì",
                    Title = "Kiểm tra hệ thống điện",
                    Content = "Phòng 103 cần kiểm tra lại hệ thống điện.",
                    Status = 1,
                    UserId = 1003,
                    MotelId = 1003
                },
                new Ticket
                {
                    Id = 1004,
                    Type = "Yêu cầu bảo trì",
                    Title = "Sửa chữa điều hòa",
                    Content = "Phòng 104 cần sửa chữa điều hòa.",
                    Status = 1,
                    UserId = 1001,
                    MotelId = 1004
                },
                new Ticket
                {
                    Id = 1005,
                    Type = "Yêu cầu sửa chữa",
                    Title = "Cửa phòng bị hỏng",
                    Content = "Cửa phòng 105 gặp vấn đề cần sửa chữa.",
                    Status = 0,
                    UserId = 1002,
                    MotelId = 1005
                },
                new Ticket
                {
                    Id = 1006,
                    Type = "Khiếu nại",
                    Title = "Tiếng ồn từ phòng bên cạnh",
                    Content = "Khách hàng phòng 106 phàn nàn về tiếng ồn từ phòng bên.",
                    Status = 1,
                    UserId = 1003,
                    MotelId = 1006
                },
                new Ticket
                {
                    Id = 1007,
                    Type = "Yêu cầu bảo trì",
                    Title = "Sửa chữa giường",
                    Content = "Giường phòng 107 bị hỏng cần sửa chữa.",
                    Status = 0,
                    UserId = 1001,
                    MotelId = 1007
                },
                new Ticket
                {
                    Id = 1008,
                    Type = "Khiếu nại",
                    Title = "Nhân viên phục vụ không thân thiện",
                    Content = "Khách hàng phòng 108 khiếu nại về thái độ phục vụ của nhân viên.",
                    Status = 1,
                    UserId = 1002,
                    MotelId = 1008
                },
                new Ticket
                {
                    Id = 1009,
                    Type = "Yêu cầu sửa chữa",
                    Title = "Hệ thống WiFi chập chờn",
                    Content = "Phòng 109 gặp vấn đề với WiFi, cần kiểm tra.",
                    Status = 0,
                    UserId = 1003,
                    MotelId = 1009
                },
                new Ticket
                {
                    Id = 1010,
                    Type = "Khiếu nại",
                    Title = "Thiếu nước nóng",
                    Content = "Phòng 110 không có nước nóng, cần kiểm tra.",
                    Status = 1,
                    UserId = 1001,
                    MotelId = 1010
                }
            );

            modelBuilder.Entity<Consumption>().HasData(
                new Consumption
                {
                    Id = 1001,
                    Water = 50.25,
                    Electric = 120.50,
                    Time = DateTime.Now,
                    RoomId = 1001
                },
                new Consumption
                {
                    Id = 1002,
                    Water = 40.00,
                    Electric = 110.75,
                    Time = DateTime.Now.AddMonths(-1),
                    RoomId = 1002
                },
                new Consumption
                {
                    Id = 1003,
                    Water = 60.30,
                    Electric = 130.00,
                    Time = DateTime.Now.AddMonths(-2),
                    RoomId = 1003
                },
                new Consumption
                {
                    Id = 1004,
                    Water = 55.50,
                    Electric = 115.25,
                    Time = DateTime.Now.AddMonths(-3),
                    RoomId = 1004
                },
                new Consumption
                {
                    Id = 1005,
                    Water = 52.75,
                    Electric = 125.75,
                    Time = DateTime.Now.AddMonths(-4),
                    RoomId = 1005
                },
                new Consumption
                {
                    Id = 1006,
                    Water = 58.00,
                    Electric = 118.60,
                    Time = DateTime.Now.AddMonths(-5),
                    RoomId = 1006
                },
                new Consumption
                {
                    Id = 1007,
                    Water = 61.10,
                    Electric = 122.40,
                    Time = DateTime.Now.AddMonths(-6),
                    RoomId = 1007
                },
                new Consumption
                {
                    Id = 1008,
                    Water = 53.60,
                    Electric = 119.90,
                    Time = DateTime.Now.AddMonths(-7),
                    RoomId = 1008
                },
                new Consumption
                {
                    Id = 1009,
                    Water = 56.80,
                    Electric = 121.50,
                    Time = DateTime.Now.AddMonths(-8),
                    RoomId = 1009
                },
                new Consumption
                {
                    Id = 1010,
                    Water = 59.25,
                    Electric = 123.75,
                    Time = DateTime.Now.AddMonths(-9),
                    RoomId = 1010
                }
            );

            modelBuilder.Entity<Rental>().HasData(
                new Rental
                {
                    Id = 1001,
                    TimeStart = DateTime.Now.AddMonths(-2),
                    TimeEnd = DateTime.Now.AddMonths(-1), // Đã kết thúc
                    Status = 0, // Đã kết thúc
                    UserId = 1001,
                    MotelId = 1001
                },
                new Rental
                {
                    Id = 1002,
                    TimeStart = DateTime.Now.AddMonths(-1),
                    TimeEnd = null, // Đang thuê nên TimeEnd = null
                    Status = 1, // Đang thuê
                    UserId = 1002,
                    MotelId = 1002
                },
                new Rental
                {
                    Id = 1003,
                    TimeStart = DateTime.Now.AddMonths(-3),
                    TimeEnd = null, // Đang thuê nên TimeEnd = null
                    Status = 1, // Đang thuê
                    UserId = 1003,
                    MotelId = 1003
                }
            );

            modelBuilder.Entity<Notification>().HasData(
                new Notification
                {
                    Id = 1001,
                    Type = "Thông báo khẩn cấp",
                    Title = "Cập nhật hệ thống",
                    Content = "Hệ thống sẽ bảo trì vào lúc 22h tối nay.",
                    Status = 1, // Đang hoạt động
                    UserId = 1001
                },
                new Notification
                {
                    Id = 1002,
                    Type = "Tin nhắn mới",
                    Title = "Tin nhắn từ ban quản lý",
                    Content = "Bạn có thông báo mới từ ban quản lý.",
                    Status = 0, // Đã đọc
                    UserId = 1002
                },
                new Notification
                {
                    Id = 1003,
                    Type = "Nhắc nhở",
                    Title = "Nhắc nhở thanh toán",
                    Content = "Bạn còn nợ tiền thuê phòng tháng này.",
                    Status = 1, // Chưa đọc
                    UserId = 1003
                }
            );


            var reviews = new List<Review>();
            var random = new Random();
            int reviewId = 1001;

            for (int motelId = 1001; motelId <= 1010; motelId++)
            {
                int numberOfReviews = random.Next(1, 6);

                for (int i = 0; i < numberOfReviews; i++)
                {
                    reviews.Add(new Review
                    {
                        Id = reviewId++,
                        Rating = random.Next(1, 6), 
                        Content = $"Review cho MotelId {motelId}",
                        UserId = 1001 + random.Next(0, 3),
                        MotelId = motelId
                    });
                }
            }

            modelBuilder.Entity<Review>().HasData(reviews);

        }
    }
}
