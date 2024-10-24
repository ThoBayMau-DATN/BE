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
        public DbSet<Image> Image { get; set; }
        public DbSet<Motel> Motel { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Term> Term { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<User_Notification> User_Notification { get; set; }
        public DbSet<Ticket_Log> Ticket_Log { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1001,
                    FullName = "Nguyễn Văn A",
                    Phone = "0901234567",
                    Email = "vana@example.com",
                    Avatar = "avatar1.png",
                    CreateDate = DateTime.Now,
                    Status = true
                },
                new User
                {
                    Id = 1002,
                    FullName = "Trần Thị B",
                    Phone = "0902345678",
                    Email = "thib@example.com",
                    Avatar = "avatar2.png",
                    CreateDate = DateTime.Now,
                    Status = true
                },
                new User
                {
                    Id = 1003,
                    FullName = "Lê Văn C",
                    Phone = "0903456789",
                    Email = "vanc@example.com",
                    Avatar = "avatar3.png",
                    CreateDate = DateTime.Now,
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
                    Status = 1, // Đang hoạt động
                    UserId = 1001,
                },
                new Motel
                {
                    Id = 1002,
                    Name = "Tro B",
                    Address = "456 Đường Sông, Quận 2, TP. HCM",
                    Location = "10.762623, 106.660173",
                    Status = 0, // Tạm ngừng
                    UserId = 1002,
                },
                new Motel
                {
                    Id = 1003,
                    Name = "Tro C",
                    Address = "789 Đường Núi, Quận 3, TP. HCM",
                    Location = "10.762624, 106.660174",
                    Status = 1, // Đang hoạt động
                    UserId = 1003,
                },
                new Motel
                {
                    Id = 1004,
                    Name = "Tro D",
                    Address = "101 Đường Biển, Quận 4, TP. HCM",
                    Location = "10.762625, 106.660175",
                    Status = 1,
                    UserId = 1001,
                },
                new Motel
                {
                    Id = 1005,
                    Name = "Tro E",
                    Address = "202 Đường Mặt Trăng, Quận 5, TP. HCM",
                    Location = "10.762626, 106.660176",
                    Status = 0,
                    UserId = 1002,
                },
                new Motel
                {
                    Id = 1006,
                    Name = "Tro f",
                    Address = "303 Đường Bình Yên, Quận 6, TP. HCM",
                    Location = "10.762627, 106.660177",
                    Status = 1,
                    UserId = 1003,
                },
                new Motel
                {
                    Id = 1007,
                    Name = "Tro g",
                    Address = "404 Đường Hồng Hà, Quận 7, TP. HCM",
                    Location = "10.762628, 106.660178",
                    Status = 1,
                    UserId = 1001,
                },
                new Motel
                {
                    Id = 1008,
                    Name = "Tro H",
                    Address = "505 Đường Biển Xanh, Quận 8, TP. HCM",
                    Location = "10.762629, 106.660179",
                    Status = 0,
                    UserId = 1002,
                },
                new Motel
                {
                    Id = 1009,
                    Name = "Tro I",
                    Address = "606 Đường Núi Ngàn, Quận 9, TP. HCM",
                    Location = "10.762630, 106.660180",
                    Status = 1,
                    UserId = 1003,
                },
                new Motel
                {
                    Id = 1010,
                    Name = "Tro j",
                    Address = "707 Đường An Bình, Quận 10, TP. HCM",
                    Location = "10.762631, 106.660181",
                    Status = 1,
                    UserId = 1001,
                }
            );

            modelBuilder.Entity<Price>().HasData(
                new Price
                {
                    Id = 1001,
                    Water = 5000,
                    Electric = 3000,
                    Other = 1000,
                    IsActive = true,
                    MotelId = 1001
                },
                new Price
                {
                    Id = 1002,
                    Water = 6000,
                    Electric = 3500,
                    Other = 1500,
                    IsActive = true,
                    MotelId = 1002
                },
                new Price
                {
                    Id = 1003,
                    Water = 5500,
                    Electric = 3200,
                    Other = 1200,
                    IsActive = false,
                    MotelId = 1003
                },
                new Price
                {
                    Id = 1004,
                    Water = 6200,
                    Electric = 3400,
                    Other = 1300,
                    IsActive = true,
                    MotelId = 1004
                },
                new Price
                {
                    Id = 1005,
                    Water = 5800,
                    Electric = 3100,
                    Other = 1400,
                    IsActive = false,
                    MotelId = 1005
                },
                new Price
                {
                    Id = 1006,
                    Water = 6100,
                    Electric = 3600,
                    Other = 1600,
                    IsActive = true,
                    MotelId = 1006
                },
                new Price
                {
                    Id = 1007,
                    Water = 5700,
                    Electric = 3300,
                    Other = 1100,
                    IsActive = true,
                    MotelId = 1007
                },
                new Price
                {
                    Id = 1008,
                    Water = 5900,
                    Electric = 3400,
                    Other = 1700,
                    IsActive = false,
                    MotelId = 1008
                },
                new Price
                {
                    Id = 1009,
                    Water = 5600,
                    Electric = 3200,
                    Other = 1800,
                    IsActive = true,
                    MotelId = 1009
                },
                new Price
                {
                    Id = 1010,
                    Water = 6000,
                    Electric = 3500,
                    Other = 1900,
                    IsActive = true,
                    MotelId = 1010
                }
            );

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = 1001,
                    RoomNumber = 101,
                    Price = 500000,
                    Status = 1, // Đang hoạt động
                    MotelId = 1001
                },
                new Room
                {
                    Id = 1002,
                    RoomNumber = 102,
                    Price = 600000,
                    Status = 0, // Tạm ngừng
                    MotelId = 1002
                },
                new Room
                {
                    Id = 1003,
                    RoomNumber = 103,
                    Price = 700000,
                    Status = 1,
                    MotelId = 1003
                },
                new Room
                {
                    Id = 1004,
                    RoomNumber = 104,
                    Price = 800000,
                    Status = 1,
                    MotelId = 1004
                },
                new Room
                {
                    Id = 1005,
                    RoomNumber = 105,
                    Price = 900000,
                    Status = 0,
                    MotelId = 1005
                },
                new Room
                {
                    Id = 1006,
                    RoomNumber = 106,
                    Price = 1000000,
                    Status = 1,
                    MotelId = 1006
                },
                new Room
                {
                    Id = 1007,
                    RoomNumber = 107,
                    Price = 1100000,
                    Status = 1,
                    MotelId = 1007
                },
                new Room
                {
                    Id = 1008,
                    RoomNumber = 108,
                    Price = 1200000,
                    Status = 0,
                    MotelId = 1008
                },
                new Room
                {
                    Id = 1009,
                    RoomNumber = 109,
                    Price = 1300000,
                    Status = 1,
                    MotelId = 1009
                },
                new Room
                {
                    Id = 1010,
                    RoomNumber = 110,
                    Price = 1400000,
                    Status = 1,
                    MotelId = 1010
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
