namespace BACK_END.Models
{
    public class Price
    {
        public int Id { get; set; }
        public int Water { get; set; }
        public int Electric { get; set; }
        public int Other { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int MotelId { get; set; }
        public Motel? Motel { get; set; }
    }
}
