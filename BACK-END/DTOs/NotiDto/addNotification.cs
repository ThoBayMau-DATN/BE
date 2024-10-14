using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.DTOs.NotiDto
{
    public class addNotification
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
    }
}
