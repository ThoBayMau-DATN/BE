namespace BACK_END.Models
{
    public class Term
    {
        public int Id { get; set; }
        public string? Link { get; set; }
        public int MotelId { get; set; }
        public Motel? Motel { get; set; }
    }
}
