using System.ComponentModel.DataAnnotations;

namespace BACK_END.DTOs.NotiDto
{
    public class updateNotification
    {
        [Required(ErrorMessage = "Loại thông báo không được để trống")]
        public int Type { get; set; }
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(100, ErrorMessage = "Nội dung không quá 100 kí tự")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Nội dung không được để trống")]
        [StringLength(500, ErrorMessage = "Nội dung không quá 500 kí tự")]
        public string? Content { get; set; }

    }
}
