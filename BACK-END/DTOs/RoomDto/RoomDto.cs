using System.ComponentModel.DataAnnotations.Schema;
using BACK_END.Models;

namespace BACK_END.DTOs.RoomDto
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int? TotalUser { get; set; }
        public int Status { get; set; }
        public RoomDto_RoomType? RoomType { get; set; }
        public List<RoomImageDto>? Images { get; set; }
        public List<RoomDto_History_User>? Users { get; set; }
        public ConsumptionDto? Consumption { get; set; }
    }

    public class RoomDto_RoomType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Area { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
    }

    public class RoomDto_History_User
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }

    }
}
