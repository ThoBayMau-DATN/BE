using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.DTOs.Auth
{
    public class DangNhapRepository
    {
        public string HoTen { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? SDT { get; set; } = string.Empty;
        public string? Anh { get; set; } = string.Empty;
        public bool TrangThai { get; set; }
    }

}
