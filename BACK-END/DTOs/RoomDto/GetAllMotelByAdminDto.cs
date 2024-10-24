using BACK_END.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.DTOs.RoomDto
{
    public class GetAllMotelByAdminDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Acreage { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string? NameOwner { get; set; }
        public int TotalRoom { get; set; }
    }
}
