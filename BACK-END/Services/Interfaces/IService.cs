
using BACK_END.DTOs.RoomDto;
using BACK_END.DTOs.ServiceDto;


namespace BACK_END.Services.Interfaces
{
    public interface IService
    {

        Task<List<GetServiceDto>?> GetServiceByMotelId(int motelId);
        Task<GetServiceDto?> GetServiceById(int serviceId);
        Task<List<GetServiceDto>?> EditService(List<EditServiceDto> dto);
        Task<List<GetServiceDto>> AddService(List<AddServiceDto> service);
        Task<bool> DeleteService(List<int>? serviceId);
    }
}