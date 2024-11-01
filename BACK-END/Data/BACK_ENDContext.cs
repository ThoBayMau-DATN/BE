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
        public DbSet<Consumption> Consumption { get; set; }
        public DbSet<Rental> Rental { get; set; }
    }
}
