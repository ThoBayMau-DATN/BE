
using BACK_END.DTOs.RoomDto;


namespace BACK_END.Services.Interfaces
{
    public interface IRoom
    {

        /*Task<List<GetAllRoomRepositoryDto>?> GetAllRoomByUser(string searchAddress, string sortColumn, string sortOrder, int pageNumber, int pageSize);*/
        Task<PagedResultDto<RoomMotelDto>?> GetAllMotelByAdmin(MotelQueryDto queryDto);
        Task<PagedResultDto<RoomMotelDto>?> GetMotelByOwner(int userId, MotelQueryDto queryDto);
        Task<RoomMotelDto?> AddMotel(AddMotelDto addMotelDto);
        Task<GetMotelByIdDto?> GetMotelById(int motelId);
        Task<GetMotelEditDto?> GetMotelEdit(int motelId);
        Task<GetMotelByIdDto?> EditMotel(EditMotelDto editMotelDto);
        Task<bool> RejectMotel(int motelId);
        Task<bool> ApproveMotel(int motelId);
        Task<bool> LockMotel(int motelId);
        Task<bool> UnlockMotel(int motelId);
        Task<bool> DeleteMotel(int motelId);

        Task<List<RoomTypeDto>?> GetRoomTypeByMotelId(int motelId);
        Task<bool> AddRoom(AddRoomDto dto);
        Task<RoomTypeDto?> AddRoomType(AddRoomTypeDto dto);

        Task<RoomDto?> GetRoomById(int roomTypeId);
        Task<GetRoomTypeByEditDto?> GetRoomTypeByEdit(int roomTypeId);
        Task<GetRoomTypeByEditDto?> EditRoomType(EditRoomTypeDto dto);
        Task<PagedResultDto<GetHistoryDto>?> GetHistoryByRoomId(int roomId, RoomHistoryQueryDto dto);
        Task<List<GetRoomByExportBillDto>?> GetRoomByExportBill(int roomTypeId);
        Task<bool> AddElectricAndWaterToBill(AddElectricAndWaterDto dto);
        Task<GetPriceByRoomTypeIdDto?> GetPriceByRoomTypeId(int roomTypeId);
        Task<List<RoomUserDto>?> FindUser(string search);
        Task<bool> AddUserToRoom(AddUserToRoomDto dto);
        Task<bool> DeleteUserFromRoom(DeleteUserFromRoomDto dto);
        Task<PagedResultDto<GetBillByRoomIdDto>?> GetBillByRoomId(int roomId, BillQueryDto dto);
        Task<GetBillByRoomIdDto?> GetBillById(int id);
        Task<bool> DaThanhToanBill(int id);
        Task<bool> LockRoom(int roomId);
        Task<bool> CheckIsLockRoom(int roomId);

        // Task<List<GetRoomByMotelIdDto>?> GetRoomByMotelId(int motelId);
        // Task<bool> AddRoom(AddRoomDto dto);
        // Task<bool> AddMultiRoom(AddMultiRoomDto dto);
        // Task<bool> RoomNumberExists(int motelId, int roomNumber);
        // Task<bool> EditRoomById(int motelId, EditRoomByIdDto dto);
        // Task<MotelRoomDto?> GetRoomById(int RoomId);
        // Task<bool> DeleteUserFromRoom(int RoomId, int userId);
        // Task<bool> AddUserToRoom(AddUserToRoomDto dto);
        // Task<MotelRoomDto?> Roomtest(int roomId);
        // Task<bool> ChangeRoomStatusToInactive(int roomId);
        // Task<bool> ChangeRoomStatusToActive(int roomId);


        //Task<List<GetAllRoomRepositoryDto>?> GetAllRoomByUser(string searchAddress,string sortColumn, string sortOrder, int pageNumber, int pageSize);

    }
}