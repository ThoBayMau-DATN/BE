using Microsoft.AspNetCore.Razor.Language.Intermediate;

namespace BACK_END.DTOs.Repository
{
    public class ApiResponse<T>
    {
        public int? Code { get; set; } 
        public string? Status { get; set; } // "success" hoặc "error"
        public string? Message { get; set; } // Thông điệp ngắn gọn
        public T? Data { get; set; } // Dữ liệu trả về
        //phân trang nếu có
    }
}
