using BACK_END.Data;
using BACK_END.DTOs.Auth;
using BACK_END.Mappers;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace BACK_END.Services.Repositories
{
    public class AuthRepository : IAuth
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly TokenService _tokenService;
        private readonly BACK_ENDContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMemoryCache _cache;

        public AuthRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, TokenService tokenService, BACK_ENDContext db, IWebHostEnvironment webHostEnvironment,
            IMemoryCache cache)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _cache = cache;
        }

        public async Task<bool> CheckEmail(string email)
        {
            try
            {
                if (email == null)
                {
                    return false;
                }
                var emailCheck = await _userManager.FindByEmailAsync(email);
                if (emailCheck == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<DangNhapRepository?> CheckSDT(string sdt)
        {
            try
            {
                if (sdt == null)
                {
                    return null;
                }
                var ngDung = await _db.User.FirstOrDefaultAsync(x => x.PhoneNumber == sdt);
                return ngDung?.MapToDangNhapRepository() ?? null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<string> DangKyUser(DangKyUserDto model)
        {
            try
            {

                if (model != null)
                {
                    var RegisterDto = new RegisterDto
                    {
                        Username = model.Email ?? "",
                        Email = model.Email ?? "",
                        Password = model.Password ?? "",
                        PhoneNumber = model.Phone ?? "",
                        Role = "Customer"
                    };
                    var resultRegister = await RegisterAsync(RegisterDto);
                    if (resultRegister != "Thêm tài khoản vào IdentityUser thành công.")
                    {
                        return resultRegister;
                    }
                    var nguoiDung = new User
                    {
                        Email = model.Email ?? "",
                        FullName = model.Name ?? "",
                        PhoneNumber = model.Phone ?? ""
                    };

                    _db.User.Add(nguoiDung);
                    var resultAddNguoiDung = await _db.SaveChangesAsync();
                    if (resultAddNguoiDung > 0)
                    {
                        return "Đăng ký tài khoản thành công.";
                    }
                }
                return "Du lieu ko dc nhap vao";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<DangNhapRepository?> DangNhap(string sdt)
        {
            try
            {
                var nguoiDung = await _db.User.FirstOrDefaultAsync(x => x.PhoneNumber == sdt);
                if (nguoiDung != null)
                {
                    return nguoiDung.MapToDangNhapRepository();
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> LoginAsync(LoginDto model)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == model.Phone);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var token = await _tokenService.GenerateTokenAsync(user);
                    return token;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> RegisterAsync(RegisterDto model)
        {
            try
            {

                string[] roleNames = { "Admin", "Staff", "Motel", "Customer" };
                if (!roleNames.Contains(model.Role))
                {
                    return "Invalid role";
                }
                var user = new IdentityUser { UserName = model.Username, Email = model.Email, PhoneNumber = model.PhoneNumber };

                var result = await _userManager.CreateAsync(user, model.Password);
                int countAddRoleAndUser = 0;
                if (result.Succeeded)
                {
                    var resultRole = await _userManager.AddToRoleAsync(user, model.Role);
                    if (resultRole.Succeeded)
                    {
                        countAddRoleAndUser++;
                    }
                }
                if (countAddRoleAndUser > 0)
                {

                    return "Thêm tài khoản vào IdentityUser thành công.";
                }
                else
                {
                    var errorMessage = string.Join(" ", result.Errors.Select(e => e.Description));
                    return errorMessage;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public bool CheckOtp(string model)
        {
            string otpCode = null;

            if (_cache.TryGetValue($"otp", out string cacheData))
            {
                otpCode = cacheData;
            }

            if (otpCode == null) return false;

            if (model != otpCode) return false;

            _cache.Remove("otp");

            return true;
        }

        public async Task<bool> ChangePassword(ChangePassWord model)
        {
            try
            {
                if (model.Password != model.ConfimPassWord) return false;

                string email = null;

                if (_cache.TryGetValue($"email", out string cacheData))
                {
                    email = cacheData;
                }

                if (email == null) return false;

                var user = await _userManager.FindByEmailAsync(email);

                if (user == null) return false;

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var changePasswordResult = await _userManager.ResetPasswordAsync(user, token, model.Password);

                return changePasswordResult.Succeeded;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return false;
            }
        }

        public async Task<string> SenderEmailOtp(ForgetPassword model)
        {
            try
            {
                // Tìm user theo số điện thoại
                var user = await _userManager.Users
                    .FirstOrDefaultAsync(u => u.PhoneNumber == model.PhoneNumber);

                if (user == null)
                    return null;

                // Lấy email từ user tìm được
                var email = user.Email;
                if (string.IsNullOrEmpty(email))
                    return null;

                string content = GetEmailTemplateContent("SenderOtpEmail.html");
                if (string.IsNullOrEmpty(content))
                    return null;

                string otpCode = UserMapper.GenerateRandomNumericString(4);

                content = content.Replace("{{otpCode}}", otpCode);

                bool emailSent = UserMapper.SenderEmail(content, email);
                if (!emailSent)
                    return null;

                _cache.Set($"otp", otpCode, TimeSpan.FromMinutes(1)); // sét thời gian tồn tại cho mã otp

                _cache.Set($"email", email, TimeSpan.FromMinutes(30));

                return otpCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return null;
            }
        }

        private string GetEmailTemplateContent(string templateFileName)
        {
            try
            {
                var webRoot = _webHostEnvironment.WebRootPath;
                string filePath = Path.Combine(webRoot, "Template", templateFileName);

                if (System.IO.File.Exists(filePath))
                {
                    return System.IO.File.ReadAllText(filePath);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi đọc file template: {ex.Message}");
                return null;
            }
        }
    }
}
