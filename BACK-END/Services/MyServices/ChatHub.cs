using BACK_END.DTOs.ChatDTO;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace BACK_END.Services.MyServices
{
    //public class ChatHub : Hub
    //{
    //    private readonly IMessage _message;

    //    public ChatHub(IMessage message)
    //    {
    //        _message = message;
    //    }

    //    public async Task SendMessage(int senderId, int receiverId, string message)
    //    {
    //        // Gửi tin nhắn đến người nhận
    //        await Clients.Group($"user_{receiverId}").SendAsync("ReceiveMessage", senderId, message);

    //        // Gửi lại tin nhắn cho người gửi (hiển thị trực tiếp)
    //        await Clients.Group($"user_{senderId}").SendAsync("ReceiveMessage", senderId, message);
    //    }

    //    public async Task JoinGroup(int userId)
    //    {
    //        await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");
    //    }

    //}

    public class ChatHub : Hub
    {
        private readonly IMessage _message;

        public ChatHub(IMessage message)
        {
            _message = message;
        }

        //public async Task SendMessage(int senderId, int receiverId, string message)
        //{
        //    // Lưu tin nhắn vào cơ sở dữ liệu
        //    var newMessage = new MessageDTO
        //    {
        //        SenderId = senderId,
        //        ReceiverId = receiverId,
        //        Content = message,
        //        Time = DateTime.Now
        //    };

        //    var savedMessage = await _message.createMessageAsync(newMessage);

        //    if (savedMessage != null)
        //    {
        //        // Gửi tin nhắn tới người nhận
        //        await Clients.Group($"user_{receiverId}").SendAsync("ReceiveMessage", senderId, message, DateTime.Now);

        //        // Gửi tin nhắn lại cho người gửi (hiển thị trực tiếp)
        //        await Clients.Group($"user_{senderId}").SendAsync("ReceiveMessage", senderId, message, DateTime.Now);
        //    }
        //}

        //public async Task JoinGroup(int userId)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");
        //}

        public async Task SendMessage(int senderId, int receiverId, string message)
        {
            var newMessage = new MessageDTO
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Content = message,
                Time = DateTime.Now
            };

            var savedMessage = await _message.createMessageAsync(newMessage);

            if (savedMessage != null)
            {
                // Gửi tin nhắn đến người nhận trong nhóm
                await Clients.Group($"user_{receiverId}").SendAsync("ReceiveMessage", senderId, message, DateTime.Now);

                // Gửi tin nhắn lại cho người gửi (để hiển thị ngay lập tức trên giao diện người gửi)
                await Clients.Group($"user_{senderId}").SendAsync("ReceiveMessage", senderId, message, DateTime.Now);
            }
        }

        public async Task JoinGroup(int userId)
        {
            // Thêm người dùng vào nhóm cụ thể
            await Groups.AddToGroupAsync(Context.ConnectionId, $"user_{userId}");
        }

    }

}
