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

        public DbSet<BACK_END.Models.PhongTro> PhongTro { get; set; } = default!;
        public DbSet<BACK_END.Models.ChiTiet_HoaDon> ChiTiet_HoaDon { get; set; } = default!;
        public DbSet<BACK_END.Models.DayTro> DayTro { get; set; } = default!;
        public DbSet<BACK_END.Models.DayTro_FIle> DayTro_FIle { get; set; } = default!;
        public DbSet<BACK_END.Models.DichVu> DichVu { get; set; } = default!;
        public DbSet<BACK_END.Models.DichVu_DayTro> DichVu_DayTro { get; set; } = default!;
        public DbSet<BACK_END.Models.File> File { get; set; } = default!;
        public DbSet<BACK_END.Models.HoaDon> HoaDon { get; set; } = default!;
        public DbSet<BACK_END.Models.LoaiTicket> LoaiTicket { get; set; } = default!;
        public DbSet<BACK_END.Models.MucDoUuTien> MucDoUuTien { get; set; } = default!;
        public DbSet<BACK_END.Models.NguoiDung> NguoiDung { get; set; } = default!;
        public DbSet<BACK_END.Models.PhongTro_FIle> PhongTro_FIle { get; set; } = default!;
        public DbSet<BACK_END.Models.Ticket> Ticket { get; set; } = default!;
        public DbSet<BACK_END.Models.Ticket_File> Ticket_File { get; set; } = default!;
        public DbSet<BACK_END.Models.XuLy_Ticket> XuLy_Ticket { get; set; } = default!;
        public DbSet<BACK_END.Models.ThueTro> ThueTro { get; set; } = default!;

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.NguoiDung)
                .WithMany()
                .HasForeignKey(u => u.NguoiDungId);
        }*/
    }
}
