using BACK_END.Data;
using BACK_END.DTOs.Auth;
using BACK_END.Mappers;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace BACK_END.Services.Repositories
{
    public class AuthRepository : IAuth
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly TokenService _tokenService;
        private readonly BACK_ENDContext _db;

        public AuthRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, TokenService tokenService, BACK_ENDContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _db = db;
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
            } catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<bool> CheckSDT(string sdt)
        {
            try
            {
                if (sdt == null)
                {
                    return false;
                }
                var sdtCheck = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == sdt);
                if (sdtCheck == null)
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
                        Password = model.MatKhau ?? "",
                        PhoneNumber = model.SoDienThoai ?? "",
                        Role = "Customer"
                    };
                    var resultRegister = await RegisterAsync(RegisterDto);
                    if (resultRegister != "Thêm tài khoản vào IdentityUser thành công.")
                    {
                        return resultRegister;
                    }
                    var nguoiDung = new NguoiDung
                    {
                        Email = model.Email ?? "",
                        HoTen = model.HoTen ?? "",
                        SDT = model.SoDienThoai ?? ""
                    };

                    _db.NguoiDung.Add(nguoiDung);
                    var resultAddNguoiDung = await _db.SaveChangesAsync();
                    if (resultAddNguoiDung > 0)
                    {
                        return "Đăng ký tài khoản thành công.";
                    }
                }
                return "Du lieu ko dc nhap vao";
            } catch (Exception ex)
            {
                return ex.Message;
            }
            
        }

        public async Task<DangNhapRepository?> DangNhap(string email)
        {
            try
            {
                var nguoiDung = await _db.NguoiDung.FirstOrDefaultAsync(x => x.Email == email);
                if (nguoiDung != null)
                {
                    return nguoiDung.MapToDangNhapRepository();
                }
                return null;
            } catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> LoginAsync(LoginDto model)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var token = await _tokenService.GenerateTokenAsync(user);
                    return token;
                } else
                {
                    return string.Empty;
                }
            } catch (Exception ex)
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
                } else
                {
                    var errorMessage = string.Join(" ", result.Errors.Select(e => e.Description));
                    return errorMessage;
                }
            } catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
