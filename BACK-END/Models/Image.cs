namespace BACK_END.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string? Link { get; set; }
        public string? Type { get; set; }
        public int? Room_TypeId { get; set; }
        public Room_Type? Room_Type { get; set; }
        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }
    }

}
