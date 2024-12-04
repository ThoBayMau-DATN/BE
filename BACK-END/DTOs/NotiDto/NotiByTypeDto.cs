namespace BACK_END.DTOs.NotiDto
{
    public class NotiByTypeDto
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Sender { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
