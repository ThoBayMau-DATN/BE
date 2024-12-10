namespace BACK_END.DTOs.RoomDto
{
    public class GetBillByRoomIdDto
    {
        public int Id { get; set; }
        public int PriceRoom { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int Total { get; set; }
        public int? RoomId { get; set; }
        public GetBillByRoomIdDto_Room? Room { get; set; } 
        public int? UserId { get; set; }
        public RoomUserDto? User { get; set; }
        public List<GetBillByRoomIdDto_ServiceBill>? ServiceBills { get; set; }
    }

    public class GetBillByRoomIdDto_Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
    }

    public class GetBillByRoomIdDto_ServiceBill
    {
         public int Id { get; set; }
        public string? Name { get; set; }
        public int Price_Service { get; set; }
        public int Quantity { get; set; }
    }
}
