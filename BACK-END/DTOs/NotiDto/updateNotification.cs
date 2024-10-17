using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.DTOs.NotiDto
{
    public class updateNotification
    {
        [Required(ErrorMessage = "Loại thông báo không được để trống")]
        [StringLength(50, ErrorMessage = "Loại thông báo không quá 50 kí tự")]
        public string Type { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(100, ErrorMessage = "Tiêu đề không được quá 100 kí tự")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nội dung không được để trống")]
        [StringLength(500, ErrorMessage = "Nội dung không quá 500 kí tự")]
        public string Content { get; set; } = string.Empty;

        [Range(0, 1, ErrorMessage = ("Trạng thái không hợp lệ"))]
        [Column(TypeName = "tinyint")]
        public byte Status { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
