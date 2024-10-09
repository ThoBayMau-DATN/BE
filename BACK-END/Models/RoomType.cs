using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;
        [Column(TypeName = "ntext")]
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
    }
}
