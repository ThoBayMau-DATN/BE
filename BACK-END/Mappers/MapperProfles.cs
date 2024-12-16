using AutoMapper;
using BACK_END.DTOs.MotelDto;
using BACK_END.DTOs.NotiDto;
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
            CreateMap<Services.MyServices.PagedList<Notification>, DTOs.NotiDto.listNotificationDto>()
            .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount))
            .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages))
            .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.CurrentPage))
            .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            CreateMap<Motel, MotelAvailabilityDTO>()
            .ForMember(dest => dest.MotelName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            //ticket
            CreateMap<Models.Ticket, DTOs.Ticket.Tickets>().ReverseMap();

            //infoticket
            CreateMap<Models.Ticket, DTOs.Ticket.Infoticket>()
            .ForMember(dest => dest.Imgs, opt => opt.MapFrom(src => src.Images.Select(i => i.Link)))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.User.FullName));

            CreateMap<Models.User, DTOs.Ticket.Receiver>().ReverseMap();

            ///map pagelist
            CreateMap<Services.MyServices.PagedList<Ticket>, DTOs.Ticket.TicketPagination>()
            .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => src.TotalCount))
            .ForMember(dest => dest.TotalPages, opt => opt.MapFrom(src => src.TotalPages))
            .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.CurrentPage))
            .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.PageSize))
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src));

            //InfomationRegisterMotel
            CreateMap<Motel, DTOs.MotelDto.InfomationRegisterMotelDTO>()
                .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.Services))
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.Room_Types))
                .ReverseMap();
            CreateMap<Service, DTOs.MotelDto.InfomationRegisterMotel_ServiceDTO>().ReverseMap();
            CreateMap<Room_Type, DTOs.MotelDto.InfomationRegisterMotel_Room_TypeDTO>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
                .ForMember(dest => dest.TotalRoom, opt => opt.MapFrom(src => src.Rooms.Count()))
                .ReverseMap();
            CreateMap<Image, DTOs.MotelDto.InfomationRegisterMotel_ImageDTO>().ReverseMap();

            //delete motel
            CreateMap<Motel, DTOs.MotelDto.ResultDeleteMotelDTO>().ReverseMap();

            //chat
            CreateMap<Message, DTOs.ChatDTO.MessageDTO>().ReverseMap();
            CreateMap<Message, DTOs.ChatDTO.ReceiverDTO>()
            .ForMember(dest => dest.Receiver, opt => opt.MapFrom((src, dest, _, context) => src.SenderId == (int)context.Items["UserId"] ? src.Receiver : src.Sender));
            CreateMap<User, DTOs.ChatDTO.ReceiverInfo>().ReverseMap();
            CreateMap<User, DTOs.ChatDTO.SearchDTO>().ReverseMap();
        }
    }
}
