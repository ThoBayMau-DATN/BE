namespace BACK_END.DTOs.StaticDto
{
    public class MotelWithEmptyRoomsDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int EmptyRoomsCount { get; set; }
        public int Status { get; set; }
    }
}
