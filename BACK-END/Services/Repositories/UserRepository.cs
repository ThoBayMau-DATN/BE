using BACK_END.Data;
using BACK_END.DTOs.UserDto;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BACK_END.Services.Repositories
{
    public class UserRepository : IUser
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BACK_ENDContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
       
        public UserRepository(BACK_ENDContext db, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _db = db;
          _roleManager = roleManager;
          _userManager = userManager;
        }

       
        public async Task<PagedList<GetAllUserRepositoryDto>> GetAllUser(string searchString, string sortColumn, string sortOrder, int pageNumber, int pageSize)
        {

            var query = _db.User.Where(x=>x.Status==true).AsQueryable();
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(x => x.FullName.Contains(searchString) || x.Email.Contains(searchString) || x.Phone.Contains(searchString));
            }
            //// Lấy danh sách người dùng trước khi phân trang (theo query)
            var users = await query.ToListAsync();
            //for (int i = 0; i < users.Count; i++)
            //{
            //    Console.WriteLine(users[i].Id);
            //    Console.WriteLine(users[i].Email);
            //}
            // key: email, value: role (1 role)
            Dictionary<string, string> userRoles = new Dictionary<string, string>();
           
            //lấy danh sách người dùng từ identity

            IList<IdentityUser> iusers = await _userManager.Users.ToListAsync(); // tất cả người dùng trong identity


           // Console.WriteLine("====================================");
            for (int i = 0; i < iusers.Count; i++)
            {
                //Console.WriteLine(iusers[i].Id);
                //Console.WriteLine(iusers[i].Email);
                var roles = await _userManager.GetRolesAsync(iusers[i]);
                for (int j = 0; j < roles.Count; j++)
                {
                    Console.WriteLine(roles[j]);
                    userRoles.Add(iusers[i].Email, roles[0]);
                }
            }
            // danh sách TẤt CẢ các người dùng trong identity
            Dictionary<string, User> userDict = new Dictionary<string, User>();
            foreach (User user in _db.User.AsQueryable())
            {
                userDict.Add(user.Email, user);
                Console.WriteLine("Email người dùng: " + user.Email);
            }
            //
            //Dictionary<string, User> userDict = new Dictionary<string, User>();
            //for (int i = 0; i < users.Count; i++)
            //{
            //    userDict.Add(users[i].Email, users[i]);
            //    Console.WriteLine("Email người dùng: " + users[i].Email);
            //}
            //lấy danh sách sau đó tìm kiếm

            var usersWithRoles = query.Select(user => new GetAllUserRepositoryDto
            {   
                Id = userDict[user.Email].Id,
                Email = user.Email,
                FullName = userDict[user.Email].FullName,
                Phone = userDict[user.Email].Phone,
                Avatar = userDict[user.Email].Avatar,
                TimeCreated = userDict[user.Email].CreateDate,
                Status = userDict[user.Email].Status,
                Role = userRoles.GetValueOrDefault(user.Email, "")
            });
            //trả về người dùng active 
           

            //sắp xếp
            if (!string.IsNullOrEmpty(sortColumn))
            {
                //query = sortOrder == "desc"
                //    ? query.OrderByDescending(GetSortProperty(sortColumn))
                //    : query.OrderBy(GetSortProperty(sortColumn));
                if (sortOrder == "desc")
                {
                    if (sortColumn == "FullName")
                    {
                        usersWithRoles = usersWithRoles.OrderByDescending(x => x.FullName);
                    }
                    else if (sortColumn == "Phone")
                    {
                        usersWithRoles = usersWithRoles.OrderByDescending(x => x.Phone);
                    }
                    else if (sortColumn == "Email")
                    {
                        usersWithRoles = usersWithRoles.OrderByDescending(x => x.Email);
                    }
                    else if (sortColumn == "TimeCreated")
                    {
                        usersWithRoles = usersWithRoles.OrderByDescending(x => x.TimeCreated);
                    }
                    else if (sortColumn == "Status")
                    {
                        usersWithRoles = usersWithRoles.OrderByDescending(x => x.Status);
                    }
                    else if (sortColumn == "Role")
                    {
                        usersWithRoles = usersWithRoles.OrderByDescending(x => x.Role);
                    }
                }
                else
                {
                    if (sortColumn == "FullName")
                    {
                        usersWithRoles = usersWithRoles.OrderBy(x => x.FullName);
                    }
                    else if (sortColumn == "Phone")
                    {
                        usersWithRoles = usersWithRoles.OrderBy(x => x.Phone);
                    }
                    else if (sortColumn == "Email")
                    {
                        usersWithRoles = usersWithRoles.OrderBy(x => x.Email);
                    }
                    else if (sortColumn == "TimeCreated")
                    {
                        usersWithRoles = usersWithRoles.OrderBy(x => x.TimeCreated);
                    }
                    else if (sortColumn == "Status")
                    {
                        usersWithRoles = usersWithRoles.OrderBy(x => x.Status);
                    }
                    else if (sortColumn == "Role")
                    {
                        usersWithRoles = usersWithRoles.OrderBy(x => x.Role);
                    }
                }
            }
            //phân trang
            var pagedResult = await PagedList<GetAllUserRepositoryDto>.CreateAsync(
               usersWithRoles,
               pageNumber,
               pageSize);
              //trả về phân trang và danh sách
              return pagedResult;   
        }

        public Task<GetAllUserRepositoryDto> GetUserById(int id)
        {
            //lấy người dùng theo id
            var query = _db.User.Where(x => x.Id == id).FirstOrDefault();
            ////nếu có người dùng
            if (query == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }


            //lấy người dùng theo email trong identity
            var identityUser = _userManager.FindByEmailAsync(query.Email).Result;
            if (identityUser == null)
            {
                throw new KeyNotFoundException($"Identity user with ID {query.Id} not found.");
            }
            //lấy role của người dùng
            var roles = _userManager.GetRolesAsync(identityUser).Result;
            Console.WriteLine("Role của người dùng: " + roles[0]);
            ////tạo user mới add role
            var users = new GetAllUserRepositoryDto
            {
                Id = query.Id,
                FullName = query.FullName,
                Phone = query.Phone,
                Email = query.Email,
                Avatar = query.Avatar,
                TimeCreated = query.CreateDate,
                Status = query.Status,
                Role = roles[0]
            };

            return Task.FromResult(users);

            //var query = _db.User.AsQueryable().Where(x => x.Id == id).FirstOrDefaultAsync();
            ////lấy người dùng theo email trong identity
            //var identityUser = _userManager.FindByEmailAsync(query.Result.Email).Result;
            //Console.WriteLine("Email người dùng: " + identityUser.Email);
            //if (identityUser == null)
            //{
            //    throw new KeyNotFoundException($"Identity user with ID {query.Result.Id} not found.");
            //}
            ////lấy role của người dùng
            //var roles = _userManager.GetRolesAsync(identityUser).Result;
            //Console.WriteLine("Role của người dùng: " + roles[0]);
            ////tạo user mới add role
            //var users = new GetAllUserRepositoryDto
            //{
            //    Id = query.Result.Id,
            //    FullName = query.Result.FullName,
            //    Phone = query.Result.Phone,
            //    Email = query.Result.Email,
            //    Avatar = query.Result.Avatar,
            //    TimeCreated = query.Result.CreateDate,
            //    Status = query.Result.Status,
            //    Role = roles[0]
            //};

            //return Task.FromResult(users);


        }
        public async Task<User?> CreateUser(CreateUserRepositoryDto userDto)
        {
            // Kiểm tra xem có người dùng nào đã tồn tại với email này không
            var existingUser = await _userManager.FindByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                //ném ngoại lệ email đã tồn tại
                throw new InvalidOperationException("Email đã tồn tại.");
            }
            //kiểm tra dữ liệu  đầu vào có hợp lệ model


            // Kiểm tra xem có người dùng nào đã tồn tại với số điện thoại này không
            var existingPhone = await _db.User.FirstOrDefaultAsync(x => x.Phone == userDto.Phone);
            if (existingPhone != null)
            {
                throw new InvalidOperationException("Số điện thoại đã tồn tại.");
            }
           

            // Tạo một thực thể User mới
            var newUser = new User
            {
                FullName = userDto.FullName,
                Phone = userDto.Phone,
                Email = userDto.Email,
                Avatar = userDto.Avatar,
                CreateDate = DateTime.Now, // Thiết lập thời gian tạo
                Status = true // Trạng thái mặc định
            };
            if (!await _roleManager.RoleExistsAsync(userDto.Role))
            {
                var role = new IdentityRole { Name = userDto.Role };
                await _roleManager.CreateAsync(role);
            }
            else
            {

            }


            // Thêm người dùng mới vào ngữ cảnh cơ sở dữ liệu
            await _db.User.AddAsync(newUser);

            // Tạo một phiên bản IdentityUser
            var identityUser = new IdentityUser
            {
                UserName = userDto.Email,
                Email = userDto.Email,
                PhoneNumber = userDto.Phone
            };

            // Tạo IdentityUser trong UserManager
            var createUserResult = await _userManager.CreateAsync(identityUser, userDto.Password);
            if (!createUserResult.Succeeded)
            {
                //trả về tin nhắn lỗi
                throw new Exception("Failed to create identity user: " + string.Join(", ", createUserResult.Errors.Select(e => e.Description)));
            }

            // Gán vai trò cho người dùng vừa tạo
            await _userManager.AddToRoleAsync(identityUser, userDto.Role);

            // Lưu tất cả các thay đổi vào cơ sở dữ liệu
            await _db.SaveChangesAsync();

           return newUser;
        }

        private Expression<Func<User, object>> GetSortProperty(string sortColumn)
        {
            throw new NotImplementedException();
        }

        public async Task<User> UpdateUser(int id, UpdateUserRepositoryDto user)
        {
            // Tìm người dùng theo ID
            var existingUser = await _db.User.FindAsync(id);
            if (existingUser == null)
                {
                throw new KeyNotFoundException($"Không tìm thấy người dùng.");
            }
            //tìm người dùng trong identity trước khi cập nhật
            var identityUser = await _userManager.FindByEmailAsync(existingUser.Email);
          
            if (identityUser == null)
            {
                throw new KeyNotFoundException($"Identity user with ID {existingUser.Id} not found.");
            }
            //kiểm tra dữ liệu người dùng có thay đổi và có trùng với người dùng khác không
            if (user.Email != existingUser.Email && user.Email != existingUser.Email)
            {
                var existingEmail = await _db.User.FirstOrDefaultAsync(x => x.Email == user.Email);
                if (existingEmail != null)
                {
                    throw new InvalidOperationException("Email đã tồn tại.");
                }
            }
            //kiểm tra dữ liệu người dùng có thay đổi và có trùng với người dùng khác không
            if (user.Phone != existingUser.Phone && user.Phone != existingUser.Phone)
            {
                var existingPhone = await _db.User.FirstOrDefaultAsync(x => x.Phone == user.Phone);
                if (existingPhone != null)
                {
                    throw new InvalidOperationException("Số điện thoại đã tồn tại.");
                }
            }

            // Cập nhật thông tin người dùng
            existingUser.FullName = user.FullName;
            existingUser.Phone = user.Phone;
            existingUser.Email = user.Email;
            existingUser.Avatar = user.Avatar;
            //tìm id người dùng trong identity


            // Cập nhật người dùng trong identity
            identityUser.Email = user.Email;
            identityUser.UserName = user.Email; // Cập nhật UserName nếu cần

            // Cập nhật vai trò nếu có sự thay đổi
            var currentRoles = await _userManager.GetRolesAsync(identityUser);
            if (currentRoles.FirstOrDefault() != user.Role)
            {
                // Gỡ bỏ vai trò cũ
                await _userManager.RemoveFromRolesAsync(identityUser, currentRoles);
                // Thêm vai trò mới
                await _userManager.AddToRoleAsync(identityUser, user.Role);
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            var result = await _userManager.UpdateAsync(identityUser);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to update identity user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            // Lưu các thay đổi vào ngữ cảnh cơ sở dữ liệu
            await _db.SaveChangesAsync();

            return existingUser; // Trả về người dùng đã được cập nhật
        }

        public Task<User> DeleteUser(int id)
        {
            // Tìm người dùng theo ID
            var existingUser = _db.User.Find(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException("404");
            }
            //tìm người dùng trong identity trước khi xóa
            var identityUser = _userManager.FindByEmailAsync(existingUser.Email).Result;
            if (identityUser == null)
            {
                throw new KeyNotFoundException("404");
            }

           //đổi trạng thái người dùng
            existingUser.Status = false;
            //identityUser.Email = identityUser.Email + "_deleted";
            //identityUser.UserName = identityUser.UserName + "_deleted";
            // Lưu các thay đổi vào cơ sở dữ liệu
            _db.SaveChanges();
            return Task.FromResult(existingUser);
        }

        public Task<User> AccecpOwnerAccount(int id)
        {
            // Tìm người dùng theo ID
            var existingUser = _db.User.Find(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            //tìm người dùng trong identity
            var identityUser = _userManager.FindByEmailAsync(existingUser.Email).Result;
            if (identityUser == null)
            {
                throw new KeyNotFoundException($"Identity user with ID {existingUser.Id} not found.");
            }
            //kiểm tra role là Owners
            var currentRoles = _userManager.GetRolesAsync(identityUser).Result;
            if (currentRoles.FirstOrDefault() != "Owners")
            {
                throw new Exception("User is not owner");
            }
            //đổi trạng thái người dùng
            existingUser.Status = true;
            // Lưu các thay đổi vào cơ sở dữ liệu
            _db.SaveChanges();
            return Task.FromResult(existingUser);

        }

   
    }
}
