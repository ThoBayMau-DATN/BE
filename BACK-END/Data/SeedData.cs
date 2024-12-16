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
            var dbContext = serviceProvider.GetRequiredService<BACK_ENDContext>();
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
            var staffUser = await userManager.FindByEmailAsync("staff@gmail.com");

            if (adminUser == null)
            {
                // Tạo tài khoản admin mặc định
                var powerUser = new IdentityUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    PhoneNumber = "0123456780"
                };

                string adminPassword = "Admin123";



                var createPowerAdmin = await userManager.CreateAsync(powerUser, adminPassword);


                if (createPowerAdmin.Succeeded)
                {

                    // Gán role Admin cho tài khoản admin
                    await userManager.AddToRoleAsync(powerUser, "Admin");
                    // Thêm thông tin vào bảng User
                    var newUser = new Models.User
                    {
                        FullName = "Admin",
                        Email = powerUser.Email,
                        Phone = "0123456780",
                        CreateDate = DateTime.Now,
                        Status = 1
                    };

                    dbContext.User.Add(newUser);
                    dbContext.SaveChanges();
                }
            }
            if (staffUser == null)
            {
                // Tạo tài khoản saff mặc định
                var powerStaff = new IdentityUser
                {
                    UserName = "staff@gmail.com",
                    Email = "staff@gmail.com",
                    PhoneNumber = "0123456788"
                };

                string adminStaff = "Staff123";

                var createPowerStaff = await userManager.CreateAsync(powerStaff, adminStaff);

                if (createPowerStaff.Succeeded)
                {
                    await userManager.AddToRoleAsync(powerStaff, "Staff");

                    var newStaff = new Models.User
                    {
                        FullName = "Staff",
                        Email = powerStaff.Email,
                        Phone = "0123456788",
                        CreateDate = DateTime.Now,
                        Status = 1
                    };
                    dbContext.User.Add(newStaff);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
