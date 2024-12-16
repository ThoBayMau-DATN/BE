using BACK_END.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Data
{
    public class BACK_ENDContext : IdentityDbContext<IdentityUser>
    {
        public BACK_ENDContext(DbContextOptions<BACK_ENDContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(m => m.Id);

                entity.HasOne(m => m.Sender)
                      .WithMany(u => u.SentMessages)
                      .HasForeignKey(m => m.SenderId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(m => m.Receiver)
                      .WithMany(u => u.ReceivedMessages)
                      .HasForeignKey(m => m.ReceiverId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }

        public DbSet<Bill> Bill { get; set; }
        public DbSet<Consumption> Consumption { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Motel> Motel { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<Package> Package { get; set; }
        public DbSet<Package_User> Package_User { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Room_History> Room_History { get; set; }
        public DbSet<Room_Type> Room_Type { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Service_Bill> Service_Bill { get; set; }
        public DbSet<Service_Room> Service_Room { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Ticket_Log> Ticket_Log { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<User_Notification> User_Notification { get; set; }
        public DbSet<Message> Message { get; set; }
    }
}
