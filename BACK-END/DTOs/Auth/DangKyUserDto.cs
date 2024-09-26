using System.ComponentModel.DataAnnotations;

namespace BACK_END.DTOs.Auth
{
    public class DangKyUserDto
    {
        [Required(ErrorMessage = "Họ tên không được để trống.")]
        public string HoTen { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 đến 20 ký tự.")]
        public string? MatKhau { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
        public string? Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng.")]
        [StringLength(10, ErrorMessage = "Số điện thoại không đúng định dạng.")]
        public string? SoDienThoai { get; set; } = string.Empty;
    }
}
