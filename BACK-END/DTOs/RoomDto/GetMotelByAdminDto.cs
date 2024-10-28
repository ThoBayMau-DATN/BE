using BACK_END.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.DTOs.RoomDto
{
    public class GetMotelByAdminDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int TotalRoom { get; set; }
        public MotelPriceDto? Price { get; set; }
        public ICollection<MotelImageDto>? Images { get; set; }
        public MotelOwnerDto? Owner { get; set; }
    }
    public class MotelOwnerDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Status { get; set; } = true;
    }
    public class MotelPriceDto
    {
        public int Id { get; set; }
        public int Water { get; set; }
        public int Electric { get; set; }
        public int Other { get; set; }
    }

    public class MotelImageDto
    {
        public int Id { get; set; }
        public string? Link { get; set; }
        public string? Type { get; set; }
    }

}
