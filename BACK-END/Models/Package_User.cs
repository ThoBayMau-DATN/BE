namespace BACK_END.Models
{
    public class Package_User
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? PackageId { get; set; }
        public Package? Package { get; set; }
    }
}
