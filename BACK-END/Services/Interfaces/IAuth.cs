﻿using BACK_END.DTOs.Auth;

namespace BACK_END.Services.Interfaces
{
    public interface IAuth
    {
        Task<string> RegisterAsync(RegisterDto model);
        Task<string> LoginAsync(LoginDto model);
        Task<string> DangKyUser(DangKyUserDto model);
        Task<bool> CheckEmail(string email);
        Task<bool> CheckSDT(string sdt);
    }
}
