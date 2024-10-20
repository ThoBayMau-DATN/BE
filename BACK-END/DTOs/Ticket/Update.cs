namespace BACK_END.DTOs.Ticket
{
    public class Update
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string? Receiver { get; set; }
    }
}
