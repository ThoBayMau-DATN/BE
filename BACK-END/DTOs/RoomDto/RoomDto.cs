using System.ComponentModel.DataAnnotations.Schema;
using BACK_END.Models;

namespace BACK_END.DTOs.RoomDto
{
    public class RoomDto
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int? TotalUser { get; set; }
        public List<RoomHistoryDto>? History { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
    }
}
