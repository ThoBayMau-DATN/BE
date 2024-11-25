namespace BACK_END.DTOs.Ticket
{
    public class NotiQuery
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 8;
        public bool Status { get; set; }
    }
}
