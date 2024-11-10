using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Motel
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Address { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Location { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? ExpriryDate { get; set; }
        public DateTime? RegisterDate { get; set; }
        public int? UserId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public User? User { get; set; }

        public virtual ICollection<Image>? Images { get; set; }
        public virtual ICollection<Room>? Rooms { get; set; }
        public virtual ICollection<Price>? Prices { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Term>? Terms { get; set; }
    }
}
