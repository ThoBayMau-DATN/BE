namespace BACK_END.DTOs.Repository
{
    public class ApiResponse<T>
    {
        public string? Status { get; set; } // "success" hoặc "error"
        public string? Message { get; set; } // Thông điệp ngắn gọn
        public T? Data { get; set; } // Dữ liệu trả về
        public object? Errors { get; set; } // Thông tin lỗi (nếu có)
    }
}
