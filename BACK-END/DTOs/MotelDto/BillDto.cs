namespace BACK_END.DTOs.MotelDto
{
    public class BillDto
    {
        public int Id { get; set; }
        public int PriceRoom { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Total { get; set; }
    }
}
