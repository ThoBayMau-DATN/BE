using BACK_END.DTOs.MainDto;
using BACK_END.DTOs.MotelDto;
using BACK_END.Models;
using BACK_END.Services.MyServices;
using BACK_END.Services.Paging;


namespace BACK_END.Services.Interfaces
{
    public interface IGetTro
    {
        Task<IEnumerable<RoomTypeWithPackageDTO>> GetRoomTypesWithFeature();

        Task<List<RoomTypeWithPackageDTO>> GetNewRoomTypesAsync();

        Task<List<RoomTypeWithPackageDTO>> GetRoomTypesUnderOneMillionAsync();

        Task<RoomTypeDTO> GetRoomTypeByRoomID(int id);

        Task<PaginatedResponse<Rentalroomuser>> GetRentalRoomHistoryAsync(string token, int pageIndex, int pageSize, string searchTerm);

        Task<PaginatedResponse<BillDto>> GetBillAsync(int id, int pageIndex, int pageSize, string searchTerm);

        Task<BilldetailDto> GetBillDetailsByIdAsync(int billId);

        //search room type by Province or Districtname or Ward
        Task<PagedList<RoomTypeDTO>> SearchRoomTypeByLocationAsync(string? Province, string? District, string? Ward, string? search, int pageNumber, int pageSize, string? sortOption, decimal? minPrice, decimal? maxPrice, double? minArea, double? maxArea, List<string>? surrounding);

        Task<Bill?> UpdateBillStatusAsync(int billId);

        Task<Bill?> GetTotalByBillAsync(int billId);
    }
}
