using AutoMapper;
using BACK_END.DTOs.MotelDto;
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

            CreateMap<Motel, MotelAvailabilityDTO>()
            .ForMember(dest => dest.MotelName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            //ticket
            CreateMap<Models.Ticket, DTOs.Ticket.Tickets>()
            .ForMember(dest => dest.Imgs, opt => opt.MapFrom(src => src.Images.Select(i => i.Link)))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.User.FullName));
        }
    }
}
