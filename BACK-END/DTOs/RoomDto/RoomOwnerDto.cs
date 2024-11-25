using BACK_END.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.DTOs.RoomDto
{
    public class RoomOwnerDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;
    }
}
