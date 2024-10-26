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
        public int Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int TotalRoom { get; set; }
        public List<string>? Images { get; set; }
        public GetOwnerDto? Owner { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
    public class GetOwnerDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
    }
}
