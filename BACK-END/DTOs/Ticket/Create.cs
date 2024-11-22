using System.ComponentModel.DataAnnotations;

namespace BACK_END.DTOs.Ticket
{
    public class Create
    {
        public int Type { get; set; }
        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Nội dung không được để trống")]
        public string Content { get; set; }
        public string? Receiver { get; set; }
        public string Token { get; set; }
        public int? MotelId { get; set; }
        public List<IFormFile>? imgs { get; set; }
    }
}
