using BACK_END.DTOs.Auth;

namespace BACK_END.Services.Interfaces
{
    public interface IAuth
    {
        Task<string> RegisterAsync(RegisterDto model);
        Task<string> LoginAsync(LoginDto model);
        Task<string> DangKyUser(DangKyUserDto model);
        Task<bool> CheckEmail(string email);
        Task<bool> CheckSDT(string sdt);
        Task<DangNhapRepository?> DangNhap(string email);

        Task<string> SenderEmailOtp(ForgetPassword model);

        Task<bool> ChangePassword(ChangePassWord model);

        bool CheckOtp(string model);
    }
}
