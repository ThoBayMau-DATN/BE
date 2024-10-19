using System.ComponentModel.DataAnnotations;

namespace BACK_END.DTOs.Auth
{
    public class DangKyUserDto
    {
        [Required(ErrorMessage = "Name không được để trống.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password không được để trống.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 20 ký tự.")]
        public string? Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        public string? Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone không được để trống.")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone phải bắt đầu bằng số 0 và có đúng 10 chữ số.")]
        public string? Phone { get; set; } = string.Empty;

    }
}
