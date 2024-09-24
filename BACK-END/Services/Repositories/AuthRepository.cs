using BACK_END.DTOs.Auth;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.AspNetCore.Identity;

namespace BACK_END.Services.Repositories
{
    public class AuthRepository : IAuth
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly TokenService _tokenService;

        public AuthRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<string> LoginAsync(LoginDto model)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(model.Username);
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
                var user = new IdentityUser { UserName = model.Username, Email = model.Email };

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
                    return "User registered successfully!";
                } else
                {
                    return "Failed to register user.";
                }
            } catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
