namespace BACK_END.DTOs.Ticket
{
    public class Infoticket
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int Status { get; set; }
        public string? Receiver { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int MotelId { get; set; }

        public List<string>? Imgs { get; set; }
    }
}
