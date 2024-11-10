using BACK_END.Data;
using BACK_END.DTOs.RoleDto;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class RoleRepository : IRole
    {
        private readonly BACK_ENDContext _db;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleRepository(BACK_ENDContext db, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _roleManager = roleManager;
        }
        public async Task<List<GetRole>> GetRole()
        {
            var role = await _roleManager.Roles.ToListAsync();
            Console.WriteLine("Role:" + role);
           var roles = await _db.Roles.Select(x => new GetRole
           {
               id = x.Id,
               Name = x.Name
           }).ToListAsync();
            return roles;
        }

    
    }
}
