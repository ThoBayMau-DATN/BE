namespace BACK_END.DTOs.ChatDTO
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
    }
}
