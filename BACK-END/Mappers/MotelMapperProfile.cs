using AutoMapper;
using BACK_END.DTOs.RoomDto;
using BACK_END.Models;

namespace BACK_END.Mappers
{
    public class MotelMapperProfile : Profile
    {
        public MotelMapperProfile()
        {
            CreateMap<Motel, GetMotelByAdminDto>()
            .ForMember(dest => dest.TotalRoom, opt => opt.MapFrom(src => src.Rooms != null ? src.Rooms.Count : 0))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Prices != null ? 
                src.Prices.OrderByDescending(p => p.CreateDate).FirstOrDefault() : null))
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
            .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.User));

            CreateMap<Motel, GetMotelByIdDto>()
                .ForMember(dest => dest.TotalRoom, opt => opt.MapFrom(src => src.Rooms != null ? src.Rooms.Count : 0))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Prices != null ? 
                    src.Prices.Where(p => p.IsActive == true).OrderByDescending(p => p.CreateDate).FirstOrDefault() : null))
                .ForMember(dest => dest.LastPrice, opt => opt.MapFrom(src => src.Prices != null ? 
                    src.Prices.Where(p => p.IsActive == false).OrderByDescending(p => p.CreateDate).FirstOrDefault() : null))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
                .ForMember(dest => dest.Terms, opt => opt.MapFrom(src => src.Terms));

            CreateMap<User, MotelOwnerDto>();
            CreateMap<Price, MotelPriceDto>();
            CreateMap<Image, MotelImageDto>();
            CreateMap<Room, MotelRoomDto>();
            CreateMap<Term, MotelTermDto>();
        }
    }


}