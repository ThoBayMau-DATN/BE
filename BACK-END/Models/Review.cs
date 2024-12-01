using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Range(1, 5)]  // Giới hạn giá trị từ 1-5
        public float Rating { get; set; }  // Đổi từ int sang float
        [Column(TypeName = "nvarchar(max)")]
        public string? Content { get; set; }
        public int? Room_TypeId { get; set; }
        public Room_Type? Room_Type { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
