using BACK_END.DTOs.RoomDto;
using BACK_END.Models;

namespace BACK_END.Services.Interfaces
{
    public interface IRoom
    {
        Task<List<GetAllRoomRepositoryDto>?> GetAllRoomByUser(string searchAddress, string sortColumn, string sortOrder, int pageNumber, int pageSize);
        Task<List<GetAllMotelByAdminDto>?> GetAllMotelByAdmin(MotelQueryDto queryDto);
        Task<List<GetAllMotelByAdminDto>?> GetMotelByOwner(int userId, MotelQueryDto queryDto);
        Task<string?> AddMotelAndRoom(AddMotelAndRoomDto model, List<IFormFile>? imageFile);
        Task<UpdateMotelDto?> UpdateMotel(int motelId, UpdateMotelDto dto);
        Task<GetMotelBydEdit?> GetMotelByIdEdit(int motelId);
        Task<bool> RejectMotel(int motelId);
        Task<bool> ApproveMotel(int motelId);
        Task<bool> DeactivateMotel(int motelId);
        Task<List<GetRoomByMotelIdDto>?> GetRoomByMotelId(int motelId);
        Task<bool> AddRoom(AddRoomDto dto);
        Task<bool> RoomNumberExists(int motelId, int roomNumber);
    }
}