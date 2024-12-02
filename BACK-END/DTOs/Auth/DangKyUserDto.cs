using System.ComponentModel.DataAnnotations;

namespace BACK_END.DTOs.Auth
{
    public class DangKyUserDto
    {
        [Required(ErrorMessage = "Tên không được để trống.")]
        [StringLength(50, ErrorMessage = "Tên không được vượt quá 50 ký tự.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 20 ký tự.")]
        public string? Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        [StringLength(50, ErrorMessage = "Email không được vượt quá 50 ký tự.")]
        public string? Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone phải bắt đầu bằng số 0 và có đúng 10 chữ số.")]
        public string? Phone { get; set; } = string.Empty;

    }
}
