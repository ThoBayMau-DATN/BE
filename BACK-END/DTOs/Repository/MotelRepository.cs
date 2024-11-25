namespace BACK_END.DTOs.Repository
{
    public class MotelRepository<T>
    {
        public int? Code { get; set; } 
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}