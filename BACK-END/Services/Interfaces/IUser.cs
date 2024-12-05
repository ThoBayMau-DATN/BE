using BACK_END.DTOs.UserDto;
using BACK_END.Models;
using BACK_END.Services.MyServices;

namespace BACK_END.Services.Interfaces
{
    public interface IUser
    {
        public Task<PagedList<GetAllUserRepositoryDto>> GetAllUser(string searchString, string sortColumn, string sortOrder, int pageNumber, int pageSize, string token);
        public Task<GetAllUserRepositoryDto> GetUserById(int id);
        public Task<User> CreateUser(CreateUserRepositoryDto user);
        public Task<User> UpdateUser(int id, UpdateUserRepositoryDto user);
        public Task<User> DeleteUser(int id);
        public Task<User> AccecpOwnerAccount(int id);
    }
}
