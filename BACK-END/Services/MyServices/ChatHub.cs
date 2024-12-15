using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace BACK_END.Services.MyServices
{
    public class ChatHub : Hub
    {
        private readonly IMessage _message;

        public ChatHub(IMessage message)
        {
            _message = message;
        }

        //public async Task SendMessage(int senderId, int receiverId, string message)
        //{
        //    // Gửi tin nhắn đến người nhận
        //    await Clients.User(senderId.ToString()).SendAsync("ReceiveMessage", senderId, message);
        //    await Clients.User(receiverId.ToString()).SendAsync("ReceiveMessage", senderId, message);
        //    var data = new DTOs.ChatDTO.MessageDTO()
        //    {
        //        SenderId = senderId,
        //        ReceiverId = receiverId,
        //        Content = message
        //    };
        //    // Lưu tin nhắn vào cơ sở dữ liệu
        //    await _message.createMessageAsync(data);
        //}

        //public async Task GetMessages(int user1Id, int user2Id)
        //{
        //    var messages = await _message.getMessageHistoryAsync(user1Id, user2Id);
        //    await Clients.Caller.SendAsync("LoadMessages", messages);
        //}

        public async Task SendMessage(int senderId, int receiverId, string message)
        {
            // Gửi tin nhắn đến người nhận
            await Clients.Group($"user_{receiverId}").SendAsync("ReceiveMessage", senderId, message);

            // Gửi lại tin nhắn cho người gửi (hiển thị trực tiếp)
            await Clients.Group($"user_{senderId}").SendAsync("ReceiveMessage", senderId, message);
        }

        public async Task JoinGroup(int userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");
        }

    }
}
