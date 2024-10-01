using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class File
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string FileName { get; set; } = string.Empty;
        public string StorageLocation { get; set; } = string.Empty;
        [Column(TypeName = "varchar(50)")]
        public string FileType { get; set; } = string.Empty;
    }

}
