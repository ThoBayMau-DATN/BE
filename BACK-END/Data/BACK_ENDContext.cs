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

        public DbSet<BACK_END.Models.Room> Room { get; set; } = default!;
        public DbSet<BACK_END.Models.OrderDetail> OrderDetail { get; set; } = default!;
        public DbSet<BACK_END.Models.BoardingHouse> BoardingHouse { get; set; } = default!;
        public DbSet<BACK_END.Models.BoardingHouse_FIle> BoardingHouse_FIle { get; set; } = default!;
        public DbSet<BACK_END.Models.Service> Services { get; set; } = default!;
        public DbSet<BACK_END.Models.Service_BoardingHouse> Service_BoardingHouse { get; set; } = default!;
        public DbSet<BACK_END.Models.File> File { get; set; } = default!;
        public DbSet<BACK_END.Models.Order> Order { get; set; } = default!;
        public DbSet<BACK_END.Models.TicketType> TicketType { get; set; } = default!;
        public DbSet<BACK_END.Models.PriorityLevel> PriorityLevel { get; set; } = default!;
        public DbSet<BACK_END.Models.User> User { get; set; } = default!;
        public DbSet<BACK_END.Models.Room_FIle> Room_FIle { get; set; } = default!;
        public DbSet<BACK_END.Models.Ticket> Ticket { get; set; } = default!;
        public DbSet<BACK_END.Models.Ticket_File> Ticket_File { get; set; } = default!;
        public DbSet<BACK_END.Models.TicketProcessing> TicketProcessing { get; set; } = default!;
        public DbSet<BACK_END.Models.RoomRental> RoomRental { get; set; } = default!;
        public DbSet<BACK_END.Models.RoomType> RoomType { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    Id = -1,
                    Area = 25.5m,
                    Price = 1500000m,
                    Quantity = 1,
                    Description = "Phòng trọ gần trường, đầy đủ tiện nghi",
                    TimeCreate = DateTime.Now,
                    Status = 1, // Available
                    BoardingHouseId = -1,
                    RoomTypeId = -1
                },
                new Room
                {
                    Id = -2,
                    Area = 30.0m,
                    Price = 2000000m,
                    Quantity = 2,
                    Description = "Phòng trọ rộng rãi, có điều hòa và ban công",
                    TimeCreate = DateTime.Now,
                    Status = 1, // Available
                    BoardingHouseId = -2,
                    RoomTypeId = -2
                },
                new Room
                {
                    Id = -3,
                    Area = 20.0m,
                    Price = 1000000m,
                    Quantity = 1,
                    Description = "Phòng nhỏ, phù hợp cho sinh viên",
                    TimeCreate = DateTime.Now,
                    Status = 1, // Available
                    BoardingHouseId = -3,
                    RoomTypeId = -1
                },
                new Room
                {
                    Id = -4,
                    Area = 40.0m,
                    Price = 3500000m,
                    Quantity = 1,
                    Description = "Phòng cao cấp, có view nhìn ra công viên",
                    TimeCreate = DateTime.Now,
                    Status = 1, // Available
                    BoardingHouseId = -4,
                    RoomTypeId = -3
                },
                new Room
                {
                    Id = -5,
                    Area = 15.0m,
                    Price = 800000m,
                    Quantity = 1,
                    Description = "Phòng tiết kiệm, nhỏ gọn, gần chợ",
                    TimeCreate = DateTime.Now,
                    Status = 1, // Available
                    BoardingHouseId = -5,
                    RoomTypeId = -1
                }
            );

            modelBuilder.Entity<RoomType>().HasData(
               new RoomType
               {
                   Id = -1,
                   Name = "Phòng đơn",
                   Description = "Phòng trọ dành cho một người ở, không gian nhỏ gọn, tiện nghi cơ bản",
                   Status = 1
               },
               new RoomType
               {
                   Id = -2,
                   Name = "Phòng đôi",
                   Description = "Phòng trọ dành cho hai người ở, không gian rộng rãi hơn, có tiện nghi đầy đủ",
                   Status = 1
               },
               new RoomType
               {
                   Id = -3,
                   Name = "Phòng gia đình",
                   Description = "Phòng trọ dành cho gia đình, không gian rộng, có bếp và phòng tắm riêng",
                   Status = 1
               },
               new RoomType
               {
                   Id = -4,
                   Name = "Phòng VIP",
                   Description = "Phòng trọ cao cấp, tiện nghi hiện đại, có view đẹp, diện tích lớn",
                   Status = 1
               },
               new RoomType
               {
                   Id = -5,
                   Name = "Phòng tiết kiệm",
                   Description = "Phòng nhỏ, giá rẻ, phù hợp cho sinh viên hoặc người có thu nhập thấp",
                   Status = 1
               }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = -1, FullName = "John Doe", Email = "johndoe@example.com", PhoneNumber = "1234567890", Avatar = "john_avatar.png", TimeCreated = DateTime.Now, Status = true },
                new User { Id = -2, FullName = "Jane Smith", Email = "janesmith@example.com", PhoneNumber = "0987654321", Avatar = "jane_avatar.png", TimeCreated = DateTime.Now, Status = true },
                new User { Id = -3, FullName = "Alice Brown", Email = "alicebrown@example.com", PhoneNumber = "1122334455", Avatar = "alice_avatar.png", TimeCreated = DateTime.Now, Status = true },
                new User { Id = -4, FullName = "Bob Johnson", Email = "bobjohnson@example.com", PhoneNumber = "5566778899", Avatar = "bob_avatar.png", TimeCreated = DateTime.Now, Status = false },
                new User { Id = -5, FullName = "Charlie White", Email = "charliewhite@example.com", PhoneNumber = "6677889900", Avatar = "charlie_avatar.png", TimeCreated = DateTime.Now, Status = true }
            );

            modelBuilder.Entity<BoardingHouse>().HasData(
                new BoardingHouse { Id = -1, Address = "123 Main St", UserId = -1, Status = 1 },
                new BoardingHouse { Id = -2, Address = "456 Oak Ave", UserId = -2, Status = 2 },
                new BoardingHouse { Id = -3, Address = "789 Pine Rd", UserId = -3, Status = 1 },
                new BoardingHouse { Id = -4, Address = "101 Maple Dr", UserId = -4, Status = 0 },
                new BoardingHouse { Id = -5, Address = "202 Birch Ln", UserId = -5, Status = 1 }
            );


        }

    }
}
