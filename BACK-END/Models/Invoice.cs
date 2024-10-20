namespace BACK_END.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int Water { get; set; }
        public int Electric { get; set; }
        public int Price { get; set; }
        public int Other { get; set; }
        public bool Status { get; set; } = false;
        public int RoomId { get; set; }
        public Room? Room { get; set; }

    }
}
