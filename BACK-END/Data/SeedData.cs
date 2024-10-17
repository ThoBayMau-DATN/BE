using Microsoft.AspNetCore.Identity;

namespace BACK_END.Data
{
    public class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            // Lấy các service cần thiết
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Tạo các role mặc định
            string[] roleNames = { "Admin", "Staff", "Owner", "Customer" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Nếu role chưa tồn tại, tạo mới role
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Kiểm tra xem tài khoản admin đã tồn tại chưa
            var adminUser = await userManager.FindByEmailAsync("admin@gmail.com");
            Console.WriteLine(adminUser);
            if (adminUser == null)
            {
                // Tạo tài khoản admin mặc định
                var powerUser = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                };

                string adminPassword = "Admin@123";

                var createPowerUser = await userManager.CreateAsync(powerUser, adminPassword);

                if (createPowerUser.Succeeded)
                {
                    // Gán role Admin cho tài khoản admin
                    await userManager.AddToRoleAsync(powerUser, "Admin");
                }
            }
        }
    }
}
 