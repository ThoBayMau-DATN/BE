using AutoMapper;
using BACK_END.DTOs.NotiDto;
using BACK_END.DTOs.RoomDto;
using BACK_END.Models;

namespace BACK_END.Mappers
{
    public class MapperProfles : Profile
    {
        public MapperProfles()
        {
            CreateMap<Notification, addNotification>().ReverseMap();
            CreateMap<Notification, updateNotification>().ReverseMap();
            CreateMap<Notification, SendNotificationDto>().ReverseMap();
            CreateMap<Room, GetRoomById>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.RoomNumber))
                .ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Area))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
        }
    }
}
