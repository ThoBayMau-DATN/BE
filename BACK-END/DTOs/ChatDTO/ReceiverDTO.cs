namespace BACK_END.DTOs.ChatDTO
{
    public class ReceiverDTO
    {
        public string? Content { get; set; }
        public ReceiverInfo? Receiver { get; set; }
    }
    public class ReceiverInfo
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Avatar { get; set; }
    }
}
