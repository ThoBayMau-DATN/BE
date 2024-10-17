namespace BACK_END.DTOs.Ticket
{
    public class Create
    {
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Status { get; set; }
        public int UserId { get; set; }
        public int MotelId { get; set; }
    }
}
