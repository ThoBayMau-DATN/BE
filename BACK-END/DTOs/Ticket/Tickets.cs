namespace BACK_END.DTOs.Ticket
{
    public class Tickets
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Status { get; set; }
    }

    public class TicketPagination
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public List<DTOs.Ticket.Tickets>? Items { get; set; }
    }
}
