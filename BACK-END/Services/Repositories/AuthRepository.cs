using BACK_END.Data;
using BACK_END.DTOs.Auth;
using BACK_END.DTOs.MainDto;
using BACK_END.DTOs.MotelDto;
using BACK_END.Mappers;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.IdentityModel.Tokens.Jwt;

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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly FirebaseStorageService _firebase;

        public AuthRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, TokenService tokenService, BACK_ENDContext db, IWebHostEnvironment webHostEnvironment,
            IMemoryCache cache, RoleManager<IdentityRole> roleManager, FirebaseStorageService firebase)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _cache = cache;
            _roleManager = roleManager;
            _firebase = firebase;
        }

        public async Task<List<string>> GetEmailsByRoleAsync(string? roleName)
        {
            try
            {
                if (string.IsNullOrEmpty(roleName))
                {
                    var adminEmails = await _userManager.GetUsersInRoleAsync("Admin");
                    var staffEmails = await _userManager.GetUsersInRoleAsync("Staff");
                    return adminEmails.Select(user => user.Email)
                                      .Concat(staffEmails.Select(user => user.Email))
                                      .ToList();
                }
                var roleExists = await _db.Roles.AnyAsync(r => r.Name == roleName);
                if (!roleExists)
                {
                    return new List<string>();
                }

                var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
                return usersInRole.Select(user => user.Email).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return new List<string>();
            }
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
                var ngDung = await _db.User.FirstOrDefaultAsync(x => x.Phone == sdt);
                return ngDung?.MapToDangNhapRepository() ?? null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<string> RegisterCustomer(DangKyUserDto model)
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
                    if (resultRegister.Success == false)
                    {
                        return resultRegister.Message;
                    }
                    var nguoiDung = new User
                    {
                        Email = model.Email ?? "",
                        FullName = model.Name ?? "",
                        Phone = model.Phone ?? ""
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
        public async Task<string> RegisterOwner(DangKyUserDto model)
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
                        Role = "Owner"
                    };
                    var resultRegister = await RegisterAsync(RegisterDto);
                    if (resultRegister.Success == false)
                    {
                        return resultRegister.Message;
                    }
                    var nguoiDung = new User
                    {
                        Email = model.Email ?? "",
                        FullName = model.Name ?? "",
                        Phone = model.Phone ?? ""
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

        public async Task<string> RegisterSaff(DangKyUserDto model)
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
                        Role = "Staff"
                    };
                    var resultRegister = await RegisterAsync(RegisterDto);
                    if (resultRegister.Success == false)
                    {
                        return resultRegister.Message;
                    }
                    var nguoiDung = new User
                    {
                        Email = model.Email ?? "",
                        FullName = model.Name ?? "",
                        Phone = model.Phone ?? ""
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
                var nguoiDung = await _db.User.FirstOrDefaultAsync(x => x.Phone == sdt);
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

        public async Task<AuthResultDto> LoginAsync(LoginDto model)
        {
            try
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == model.Phone);
                if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var token = await _tokenService.GenerateTokenAsync(user);
                    return new AuthResultDto { Success = true, Message = "Đăng nhập thành công", Token = token, Email = user.Email, Username = user.UserName };
                }
                else
                {
                    return new AuthResultDto { Success = false, Message = "Sai tài khoản hoặc mật khẩu" };
                }
            }
            catch (Exception ex)
            {
                return new AuthResultDto { Success = false, Message = ex.Message };
            }
        }

        public async Task<AuthResultDto> RegisterAsync(RegisterDto model)
        {
            var emailExists = await _userManager.FindByEmailAsync(model.Email);
            var phoneExists = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == model.PhoneNumber);
            var roleExists = await _roleManager.FindByNameAsync(model.Role);

            if (emailExists != null)
                return new AuthResultDto { Success = false, Message = "Email đã tồn tại" };

            if (phoneExists != null)
                return new AuthResultDto { Success = false, Message = "Số điện thoại đã tồn tại" };

            if (roleExists == null)
                return new AuthResultDto { Success = false, Message = "Role không tồn tại" };

            // Tạo user mới
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            // Tạo user và gán role trong một transaction
            using var transaction = await _db.Database.BeginTransactionAsync();
            try
            {
                var createResult = await _userManager.CreateAsync(user, model.Password);
                if (!createResult.Succeeded)
                    return new AuthResultDto
                    {
                        Success = false,
                        Message = string.Join(", ", createResult.Errors.Select(x => x.Description))
                    };

                var roleResult = await _userManager.AddToRoleAsync(user, model.Role);
                if (!roleResult.Succeeded)
                {
                    await transaction.RollbackAsync();
                    return new AuthResultDto
                    {
                        Success = false,
                        Message = "Không thể gán quyền cho người dùng"
                    };
                }

                await transaction.CommitAsync();
                return new AuthResultDto
                {
                    Success = true,
                    Message = "Đăng ký thành công"
                };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Log exception here
                return new AuthResultDto
                {
                    Success = false,
                    Message = "Đã xảy ra lỗi trong quá trình đăng ký"
                };
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

        public async Task<GetUserDto?> GetUserByToken(string token)
        {
            //tìm user theo token
            var userNameIdentity = HandlerToken(token);
            if (string.IsNullOrEmpty(userNameIdentity)) return null; // Thêm kiểm tra email

            var user = await _userManager.FindByNameAsync(userNameIdentity);
            if (user == null) return null;

            var myUser = await _db.User.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (myUser == null) return null;

            var userDto = new GetUserDto
            {
                Id = myUser.Id,
                Name = myUser.FullName,
                Email = myUser.Email,
                PhoneNumber = myUser.Phone,
                Role = (await _userManager.GetRolesAsync(user)).FirstOrDefault()
            };

            return userDto;
        }
        private string? HandlerToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                return jwtToken.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token error: {ex.Message}");
                return null;
            }
        }

        public async Task<string> EditRoleCustomerToOwner(string token)
        {
            var userNameIdentity = HandlerToken(token);
            if (string.IsNullOrEmpty(userNameIdentity)) return null;

            var user = await _userManager.FindByNameAsync(userNameIdentity);
            if (user == null) return null;

            var role = await _userManager.GetRolesAsync(user);
            if (role.Contains("Customer"))
            {
                var result = await _userManager.RemoveFromRoleAsync(user, "Customer");
                await _userManager.AddToRoleAsync(user, "Owner");
            }

            return "Thay đổi quyền thành công";
        }

        public async Task<userDetailDto?> UpdateUserFromToken(string token, userDetailDto userDetailDto)
        {
            var userNameIdentity = HandlerToken(token);
            if (string.IsNullOrEmpty(userNameIdentity))
                return null;
            var identityUser = await _userManager.FindByNameAsync(userNameIdentity);
            if (identityUser == null)
                return null;
            var myUser = await _db.User.FirstOrDefaultAsync(x => x.Email == identityUser.Email);
            if (myUser == null)
                return null;
            identityUser.Email = userDetailDto.Email ?? identityUser.Email;
            identityUser.PhoneNumber = userDetailDto.Phone ?? identityUser.PhoneNumber;
            var identityResult = await _userManager.UpdateAsync(identityUser);
            if (!identityResult.Succeeded)
                return null;
            myUser.FullName = userDetailDto.FullName ?? myUser.FullName;
            myUser.Phone = userDetailDto.Phone ?? myUser.Phone;
            myUser.Email = userDetailDto.Email ?? myUser.Email;
            if (userDetailDto.Avatar != null)
            {
                var avatarUrl = await _firebase.UploadFileAsync(userDetailDto.Avatar);
                if (!string.IsNullOrEmpty(avatarUrl))
                {
                    myUser.Avatar = avatarUrl;
                }
            }
            userDetailDto.AvatarLink = myUser.Avatar;
            _db.User.Update(myUser);
            await _db.SaveChangesAsync();

            return userDetailDto;

        }

        public async Task<bool> ChangePasswordFromTokenAsync(string token, ChangePasswordDto changePasswordDto)
        {
            var userNameIdentity = HandlerToken(token);
            if (string.IsNullOrEmpty(userNameIdentity)) return false;
            var identityUser = await _userManager.FindByNameAsync(userNameIdentity);
            if (identityUser == null) return false;
            var result = await _userManager.ChangePasswordAsync(identityUser, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);
            return result.Succeeded;
        }

        public async Task<UserDetailDto?> GetUserDetailsFromTokenAsync(string token)
        {
            var userNameIdentity = HandlerToken(token);
            if (string.IsNullOrEmpty(userNameIdentity))
                return null;
            var identityUser = await _userManager.FindByNameAsync(userNameIdentity);
            if (identityUser == null)
                return null;
            var user = await _db.User.FirstOrDefaultAsync(u => u.Email == identityUser.Email);
            if (user == null)
                return null;
            return new UserDetailDto
            {
                FullName = user.FullName,
                Phone = user.Phone,
                Avatar = user.Avatar,
                Email = user.Email,

            };
        }

        public async Task<RentalRoomDetailDTO?> GetRentalRoomDetailsAsync(string token)
        {
            var email = HandlerToken(token);
            if (string.IsNullOrEmpty(email)) return null;
            var user = await _db.User.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
                return null;

            // Lấy lịch sử thuê phòng
            var roomHistory = await _db.Room_History
                .Include(rh => rh.Room)
                .ThenInclude(r => r.Room_Type)
                .ThenInclude(rt => rt.Motel)
                .FirstOrDefaultAsync(rh => rh.UserId == user.Id && rh.EndDate == null);

            if (roomHistory == null)
                return null;
            var room = roomHistory.Room;
            if (room == null)
                return null;

            var bill = await _db.Bill
        .Where(b => b.RoomId == room.Id && b.UserId == user.Id)
        .OrderByDescending(b => b.CreatedDate) // Lấy hóa đơn mới nhất
        .FirstOrDefaultAsync();

            int? billId = bill?.Id;
            int? total = bill?.Total;

            // Lấy thông tin sử dụng nước và điện
            var consumption = await _db.Consumption.FirstOrDefaultAsync(c => c.RoomId == room.Id);
            int waterUsage = consumption?.Water ?? 0;
            int electricUsage = consumption?.Electricity ?? 0;
            int waterPrice = 0, electricPrice = 0, otherServicePrice = 0;
            List<OtherServiceDTO> otherServices = new List<OtherServiceDTO>();

            // Lấy các dịch vụ ngoài nước và điện
            var serviceRooms = await _db.Service_Room
                .Include(sr => sr.Service)
                .Where(sr => sr.RoomId == room.Id)
                .ToListAsync();

            foreach (var serviceRoom in serviceRooms)
            {
                var service = serviceRoom.Service;
                if (service == null) continue;

                if (service.Name?.ToLower() == "water")
                {
                    waterPrice = service.Price * waterUsage;
                }
                else if (service.Name?.ToLower() == "electric")
                {
                    electricPrice = service.Price * electricUsage;
                }
                else
                {
                    // Thêm các dịch vụ khác vào danh sách OtherServiceDTO
                    otherServices.Add(new OtherServiceDTO
                    {
                        Name = service.Name,
                        price = service.Price
                    });
                }
            }

            // Lấy hình ảnh của RoomType
            var roomImages = await _db.Image
                .Where(i => i.Room_TypeId == room.Room_TypeId)
                .Select(i => new RoomImageDTO
                {
                    Id = i.Id,
                    Link = i.Link,
                    Type = i.Type
                })
                .ToListAsync();

            // Lấy thông tin dãy trọ và chủ nhà
            var motel = room.Room_Type?.Motel;
            string ownerName = "Unknown";
            string ownerPhone = "Unknown";
            string motelName = "Unknown";
            string motelAddress = "Unknown";

            if (motel != null)
            {
                var relatedRooms = await _db.Room
                    .Include(r => r.Room_Type)
                    .Where(r => r.Room_Type != null && r.Room_Type.MotelId == motel.Id)
                    .ToListAsync();

                bool isRoomInMotel = relatedRooms.Any(r => r.Id == room.Id);

                if (isRoomInMotel)
                {
                    var motelOwner = await _db.User.FirstOrDefaultAsync(u => u.Id == motel.UserId);
                    if (motelOwner != null)
                    {
                        ownerName = motelOwner.FullName ?? "Unknown";
                        ownerPhone = motelOwner.Phone ?? "Unknown";
                    }

                    motelName = motel.Name ?? "Unknown";
                    motelAddress = motel.Address ?? "Unknown";
                }
            }

            // Kiểm tra tình trạng thanh toán
            bool hasPaid = await _db.Bill.AnyAsync(b => b.UserId == user.Id);

            // Trả về DTO RentalRoomDetailDTO
            return new RentalRoomDetailDTO
            {
                MotelName = motelName,
                MotelAdress = motelAddress,
                fullName = user.FullName,
                RoomNumber = room.RoomNumber,
                Price = room.Room_Type?.Price ?? 0,
                Area = room.Room_Type?.Area ?? 0,
                CreateDate = roomHistory.CreateDate,
                Status = hasPaid,
                WaterPrice = waterPrice,
                ElectricPrice = electricPrice,
                OtherService = otherServices, // Các dịch vụ ngoài nước và điện
                owner = ownerName,
                phone = ownerPhone,
                RoomImages = roomImages,
                BillId = billId,
                TotalMoney = total
            };
        }

    }
}
