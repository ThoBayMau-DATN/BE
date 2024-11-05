namespace BACK_END.Models
{
    public class Term
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? Link { get; set; }
        public int MotelId { get; set; }
        public Motel? Motel { get; set; }
    }
}
