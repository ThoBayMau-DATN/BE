using BACK_END.DTOs.Auth;

namespace BACK_END.Services.Interfaces
{
    public interface IAuth
    {
        Task<AuthResultDto> RegisterAsync(RegisterDto model);
        Task<AuthResultDto> LoginAsync(LoginDto model);
        Task<string> RegisterCustomer(DangKyUserDto model);
        Task<string> RegisterOwner(DangKyUserDto model);
        Task<string> RegisterSaff(DangKyUserDto model);
        Task<bool> CheckEmail(string email);
        Task<DangNhapRepository> CheckSDT(string sdt);
        Task<DangNhapRepository?> DangNhap(string email);

        Task<string> SenderEmailOtp(ForgetPassword model);

        Task<bool> ChangePassword(ChangePassWord model);

        bool CheckOtp(string model);
        Task<GetUserDto> GetUserByToken(string token);
        Task<string> EditRoleCustomerToOwner(string token);
    }
}
