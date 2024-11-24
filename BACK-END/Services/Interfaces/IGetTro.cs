using BACK_END.DTOs.MainDto;

namespace BACK_END.Services.Interfaces
{
    public interface IGetTro
    {
        Task<IEnumerable<RoomTypeWithPackageDTO>> GetRoomTypesWithFeature();

        Task<List<RoomTypeWithPackageDTO>> GetNewRoomTypesAsync();

        Task<List<RoomTypeWithPackageDTO>> GetRoomTypesUnderOneMillionAsync();

        Task<RoomTypeDTO> GetRoomTypeByRoomID(int id);

        
    }
}
