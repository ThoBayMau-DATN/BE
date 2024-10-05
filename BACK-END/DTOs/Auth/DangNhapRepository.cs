using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.DTOs.Auth
{
    public class DangNhapRepository
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Avatar { get; set; } = string.Empty;
        public bool Status { get; set; }
    }

}
