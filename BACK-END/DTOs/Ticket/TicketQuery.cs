namespace BACK_END.DTOs.Ticket
{
    public class TicketQuery
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;
        public int Status { get; set; }
        public string Token { get; set; }
    }
}
