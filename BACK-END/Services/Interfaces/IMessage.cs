namespace BACK_END.Services.Interfaces
{
    public interface IMessage
    {
        Task<DTOs.ChatDTO.MessageDTO>? createMessageAsync(DTOs.ChatDTO.MessageDTO data);
        Task<IEnumerable<DTOs.ChatDTO.MessageDTO>?> getMessageHistoryAsync(int SenderId, int ReceiverId);
        Task<IEnumerable<DTOs.ChatDTO.ReceiverDTO>?> getListUserAsync(int SenderId);
        Task<IEnumerable<DTOs.ChatDTO.SearchDTO>?> getSearchAsync(string key, int userId);
    }
}
