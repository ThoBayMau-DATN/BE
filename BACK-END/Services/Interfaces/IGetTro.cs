using BACK_END.DTOs.MainDto;

namespace BACK_END.Services.Interfaces
{
    public interface IGetTro
    {
        Task<IEnumerable<MotelDTO>> GetHighlightedMotelsAsync();

        Task<IEnumerable<MotelDTO>> GetNewMotelsAsync();
    }
}
