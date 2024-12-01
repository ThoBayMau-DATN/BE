using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class User //: IdentityUser
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? FullName { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string? Phone { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string? Email { get; set; }
        public string? Avatar { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        [Column(TypeName = "tinyint")]
        public bool Status { get; set; } = true;
    }
}
