using AutoMapper;
using BACK_END.DTOs.MotelDto;
using BACK_END.DTOs.NotiDto;
using BACK_END.DTOs.StaticDto;
using BACK_END.Models;
using System.Globalization;

namespace BACK_END.Mappers
{
    public class MapperProfles : Profile
    {
        public MapperProfles()
        {
            CreateMap<Notification, addNotification>().ReverseMap();
            CreateMap<Notification, updateNotification>().ReverseMap();
            CreateMap<Notification, SendNotificationDto>().ReverseMap();
            CreateMap<Motel, MotelAvailabilityDTO>()
            .ForMember(dest => dest.AvailableRooms, opt => opt.MapFrom(src => src.TotalRoom - src.Rooms.Count)) 
            .ForMember(dest => dest.MotelName, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<Invoice, RevenueDto>()
            .ForMember(dest => dest.Month, opt => opt.MapFrom(src => new DateTime(src.TimeCreated.Year, src.TimeCreated.Month, 1)
                .ToString("MMMM", CultureInfo.InvariantCulture)));
        }
    }
}
