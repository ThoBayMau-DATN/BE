namespace BACK_END.Models
{
    public class Media
    {
        public int Id { get; set; }
        public int? MotelId { get; set; }
        public Motel? Motel { get; set; }
        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public int? ImageId { get; set; }
        public Image? Image { get; set; }
    }
}
