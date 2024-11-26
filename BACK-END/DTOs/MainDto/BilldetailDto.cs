namespace BACK_END.DTOs.MainDto
{
    public class BilldetailDto
    {
        public string? MotelName { get; set; }
        public string? Adress { get; set; }
        public int? RoomNumber { get; set; }
        public int BillId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int Status { get; set; }
        public string? FullName { get; set; }
        public int Electric { get; set; }
        public string? WaterName { get; set; }
        public string? ElectricName { get; set; }
        public List<OtherServiceBillDTO>? OtherService { get; set; }
        public int Water { get; set; }
        public int WaterPrice { get; set; }
        public int ElectricPrice { get; set; }
        public int RoomPrice { get; set; }
    }

    public class OtherServiceBillDTO
    {
        public string? Name { get; set; }
        public int? price { get; set; }
    }
}
