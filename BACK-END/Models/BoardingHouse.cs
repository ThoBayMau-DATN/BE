using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class BoardingHouse
    {
        public int Id { get; set; }
        [Column(TypeName = "ntext")]
        public string Address { get; set; } = string.Empty;
        public int UserId { get; set; }
        public User? User { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
    }

}
