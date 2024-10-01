using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Column(TypeName = "varchar(10)")]
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Avatar { get; set; } = string.Empty;
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        [Column(TypeName = "tinyint")]
        public bool Status { get; set; } = true;
    }

}
