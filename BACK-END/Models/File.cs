using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class File
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string TenFile { get; set; } = string.Empty;
        public string ViTriLuu { get; set; } = string.Empty;
        [Column(TypeName = "varchar(50)")]
        public string KieuFile { get; set; } = string.Empty;
    }
}
