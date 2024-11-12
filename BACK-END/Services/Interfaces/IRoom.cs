
using BACK_END.DTOs.RoomDto;


namespace BACK_END.Services.Interfaces
{
    public interface IRoom
    {

        /*Task<List<GetAllRoomRepositoryDto>?> GetAllRoomByUser(string searchAddress, string sortColumn, string sortOrder, int pageNumber, int pageSize);*/
        Task<PagedResultDto<GetMotelByAdminDto>?> GetAllMotelByAdmin(MotelQueryDto queryDto);
        Task<PagedResultDto<GetMotelByIdDto>?> GetMotelByOwner(int userId, MotelQueryDto queryDto);
        Task<string?> AddMotelAndRoom(AddMotelAndRoomDto model, List<IFormFile>? imageFile, IFormFile? fileTerm);
        Task<GetMotelByIdDto?> EditMotel(int motelId, UpdateMotelDto dto);
        Task<GetMotelByIdDto?> GetMotelById(int id);
        Task<bool> RejectMotel(int motelId);
        Task<bool> ApproveMotel(int motelId);
        Task<bool> DeactivateMotel(int motelId);
        Task<bool> ActiveMotel(int motelId);
        Task<bool> RemoveMotel(int motelId);
        Task<List<GetRoomByMotelIdDto>?> GetRoomByMotelId(int motelId);
        Task<bool> AddRoom(AddRoomDto dto);
        Task<bool> AddMultiRoom(AddMultiRoomDto dto);
        Task<bool> RoomNumberExists(int motelId, int roomNumber);
        Task<bool> EditRoomById(int motelId, EditRoomByIdDto dto);
        Task<MotelRoomDto?> GetRoomById(int RoomId);
        Task<bool> DeleteUserFromRoom(int RoomId, int userId);
        Task<bool> AddUserToRoom(AddUserToRoomDto dto);
        Task<MotelRoomDto?> Roomtest(int roomId);


        //Task<List<GetAllRoomRepositoryDto>?> GetAllRoomByUser(string searchAddress,string sortColumn, string sortOrder, int pageNumber, int pageSize);

    }
}