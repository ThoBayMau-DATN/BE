using BACK_END.DTOs.RoleDto;

namespace BACK_END.Services.Interfaces
{
    public interface IRole
    {
        //get all of Role
        public Task<List<GetRole>> GetRole();
    }
}
