using BACK_END.Data;
using BACK_END.DTOs.PackageDto;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class PackageRepository : IPackage
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly BACK_ENDContext _db;
        private readonly IAuth _auth;
        public PackageRepository(BACK_ENDContext db, UserManager<IdentityUser> userManager, IAuth auth)
        {
            _db = db;
            _userManager = userManager;
            _auth = auth;
        }

        public async Task<PackageDto> CheckPackage(string token)
        {
            var isUser = await _auth.GetUserByToken(token);
            if(isUser == null)
            {
                throw new Exception("User not found");
            }
            if (isUser.Role.ToUpper() == "OWNER")
            {
                var userPackage = await _db.Package_User.FirstOrDefaultAsync(x => x.UserId == isUser.Id && x.EndDate > DateTime.Now);
                
                if (userPackage != null)
                {
                    var package = await _db.Package.FirstOrDefaultAsync(x => x.Id == userPackage.PackageId);
                    var packageDto = new PackageDto
                    {
                        Id = package.Id,
                        Name = package.Name,
                        Description = package.Description,
                        CreateDate = package.CreateDate,
                        LimitMotel = package.LimitMotel,
                        LimitRoom = package.LimitRoom,
                        Price = package.Price,
                        Status = package.Status
                    };
                    return packageDto;
                }

                return null;
            }
            else
            {
                return null;
            }
            throw new NotImplementedException();
        }

        public async Task<List<PackageDto>> GetAllPackageDto(PackageGetAllDto package )
        {
            //check token
            var isUser = await _auth.GetUserByToken(package.token);
            if (isUser.Role.ToUpper() == "OWNER" || isUser.Role.ToUpper()=="ADMIN")
            {
                //get all package
                var packages = await _db.Package.Where(x=> x.Status == true).ToListAsync();
                var packageDtos = packages.Select(x => new PackageDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    CreateDate = x.CreateDate,
                    LimitMotel = x.LimitMotel,
                    LimitRoom = x.LimitRoom,
                    Price = x.Price,
                    Status = x.Status

                }).ToList();
                return packageDtos;


            }
            else
            {

            }

            throw new NotImplementedException();
        }

        public Task<PackageDto> GetPackageDtoById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RegisterPackageDto(RegisterPackageDto registerPackageDto)
        {
            //check token
            var isUser = await _auth.GetUserByToken(registerPackageDto.token);
            if (isUser.Role.ToUpper() != "OWNER")
            {
                // xử lý nếu không phải OWNER
                throw new NotImplementedException();
            }
            else
            {
                //kiểm tra người dùng đã đăng ký gói chưa
                var checkUserPackage = await _db.Package_User.FirstOrDefaultAsync(x => x.UserId == isUser.Id && x.EndDate > DateTime.Now);
                if (checkUserPackage != null)
                {
                    checkUserPackage.EndDate = DateTime.Now;
                  
                }
                var package = await _db.Package.FirstOrDefaultAsync(x => x.Id == registerPackageDto.IdPackage);
                if (package == null)
                {
                    throw new Exception("Package not found");
                }
                var user = await _db.User.FirstOrDefaultAsync(x => x.Id == isUser.Id);
                if (user == null)
                {
                    throw new Exception("User not found");
                }

                var userPackage = new Package_User
                {
                    UserId = isUser.Id,
                    PackageId = registerPackageDto.IdPackage,
                    EndDate = DateTime.UtcNow.AddDays(30)
                };
                
                await _db.Package_User.AddAsync(userPackage);
                await _db.SaveChangesAsync();
                return true;
            }
        }

        public Task<PackageDto> UnregisterPackageDto(int id)
        {
            throw new NotImplementedException();
        }
    }
}
