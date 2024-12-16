using System.ComponentModel.DataAnnotations;

namespace BACK_END.DTOs.UserDto
{
    public class GetAllUserRepositoryDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Avatar { get; set; } = string.Empty;
        public DateTime TimeCreated { get; set; } = DateTime.Now;
        public byte Status { get; set; } = 1;
        public string Role { get; set; } = string.Empty;
        public string Vip { get; set; }
    }
    public class CreateUserRepositoryDto
    {
        [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Họ và tên không được dài quá 50 ký tự.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải có 10 chữ số.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ.")]
        [StringLength(50, ErrorMessage = "Email không được dài quá 50 ký tự.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string Password { get; set; } = string.Empty;

        public string? Avatar { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vai trò là bắt buộc.")]
        public string Role { get; set; } = string.Empty;

    }

    public class UpdateUserRepositoryDto
    {
        [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
        [StringLength(50, ErrorMessage = "Họ và tên không được dài quá 50 ký tự.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải có 10 chữ số.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [EmailAddress(ErrorMessage = "Định dạng email không hợp lệ.")]
        [StringLength(50, ErrorMessage = "Email không được dài quá 50 ký tự.")]
        public string Email { get; set; } = string.Empty;
        public string? Avatar { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vai trò là bắt buộc.")]
        public string Role { get; set; } = string.Empty;

    }




}
