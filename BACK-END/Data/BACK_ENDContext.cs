using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BACK_END.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BACK_END.Data
{
    public class BACK_ENDContext : IdentityDbContext<IdentityUser>
    {
        public BACK_ENDContext (DbContextOptions<BACK_ENDContext> options)
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

    }
}
