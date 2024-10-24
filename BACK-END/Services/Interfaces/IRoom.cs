using BACK_END.DTOs.RoomDto;
using BACK_END.Models;

namespace BACK_END.Services.Interfaces
{
    public interface IRoom
    {
        Task<List<GetAllRoomRepositoryDto>?> GetAllRoomByUser(string searchAddress, string sortColumn, string sortOrder, int pageNumber, int pageSize);
        Task<List<GetAllMotelByAdminDto>?> GetAllRoomByAdmin(MotelQueryDto queryDto);
        Task<string?> AddMotelAndRoom(AddMotelAndRoomDto model, List<IFormFile>? imageFile);
        Task<UpdateMotelDto?> UpdateMotel(int motelId, UpdateMotelDto dto);
        Task<GetMotelBydEdit?> GetMotelByIdEdit(int motelId);
        Task<bool> RejectMotel(int motelId);
        Task<bool> ApproveMotel(int motelId);
        Task<bool> DeactivateMotel(int motelId);
    }
}