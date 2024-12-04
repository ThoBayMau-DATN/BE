namespace BACK_END.DTOs.MotelDto
{
    public class ResultDeleteMotelDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public int Status { get; set; }
    }
}
