﻿namespace BACK_END.Models
{
    public class Ticket_Log
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
