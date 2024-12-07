using AutoMapper;
using BACK_END.DTOs.RoomDto;
using BACK_END.DTOs.ServiceDto;
using BACK_END.Models;
using static BACK_END.DTOs.RoomDto.RoomMotelDto;

namespace BACK_END.Mappers
{
    public class RoomMapperProfile : Profile
    {
        public RoomMapperProfile()
        {


            CreateMap<Motel, RoomMotelDto>()
            .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.RoomTypes, opt => opt.MapFrom(src => src.Room_Types))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom((src, _, _, context) => CalculateAverageRating(src)))
            .ForMember(dest => dest.TotalRoom, opt => opt.MapFrom((src, _, _, context) => CalculateTotalRooms(src)))
            .ForMember(dest => dest.TotalUser, opt => opt.MapFrom((src, _, _, context) => CalculateTotalUsers(src)));
            //room type
            CreateMap<Room_Type, RoomTypeDto>()
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Rooms))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom((src, _, _, context) => CalculateAverageRating(src)))
                .ForMember(dest => dest.TotalRoom, opt => opt.MapFrom((src, _, _, context) => CalculateTotalRooms(src)))
                .ForMember(dest => dest.TotalUser, opt => opt.MapFrom((src, _, _, context) => CalculateTotalUsers(src)));
            CreateMap<Motel, RoomTypeDto_Motel>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom((src, _, _, context) => CalculateAverageRating(src)))
                .ForMember(dest => dest.TotalRoom, opt => opt.MapFrom((src, _, _, context) => CalculateTotalRooms(src)))
                .ForMember(dest => dest.TotalUser, opt => opt.MapFrom((src, _, _, context) => CalculateTotalUsers(src)));
            CreateMap<Room, RoomTypeDto_Room>()
                .ForMember(dest => dest.TotalUser, opt => opt.MapFrom((src, _, _, context) => CalculateTotalUsers(src)));

            CreateMap<Image, RoomImageDto>().ReverseMap();
            CreateMap<Review, RoomReviewDto>().ReverseMap();

            CreateMap<User, RoomOwnerDto>();
            CreateMap<User, RoomUserDto>();

            CreateMap<Room_History, RoomHistoryDto>()
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

            CreateMap<Motel, GetMotelByIdDto>()
                .ForMember(dest => dest.Owner, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.Services));


            //get motel edit
            CreateMap<Motel, GetMotelEditDto>();
            CreateMap<Service, GetMotelEditDto_Service>();

            CreateMap<Room_Type, GetRoomTypeByMotelIdDto>()
                .ForMember(dest => dest.Rating, opt => opt.MapFrom((src, _, _, context) => CalculateAverageRating(src)))
                .ForMember(dest => dest.TotalRoom, opt => opt.MapFrom((src, _, _, context) => CalculateTotalRooms(src)))
                .ForMember(dest => dest.TotalUser, opt => opt.MapFrom((src, _, _, context) => CalculateTotalUsers(src)));

            //room
            CreateMap<Room, RoomDto>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.Room_Type))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Room_Type != null ? src.Room_Type.Images : null))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.History != null ? src.History.Where(h => h.Status == 1).Select(h => h.User) : null))
                .ForMember(dest => dest.Consumption, opt => opt.MapFrom(src => src.Consumption != null ? src.Consumption.OrderByDescending(c => c.Time).FirstOrDefault() : null));

            CreateMap<Room_Type, RoomDto_RoomType>();
            CreateMap<User, RoomDto_History_User>();
            CreateMap<Consumption, ConsumptionDto>();

            //edit room type
            CreateMap<Room_Type, GetRoomTypeByEditDto>();

            //get history
            CreateMap<Room_History, GetHistoryDto>();

            //get room by export bill
            CreateMap<Room, GetRoomByExportBillDto>()
                .ForMember(dest => dest.Consumption, opt => opt.MapFrom(src => src.Consumption != null ? src.Consumption.OrderByDescending(c => c.Time).FirstOrDefault() : null));

            //get bill by room id
            CreateMap<Bill, GetBillByRoomIdDto>()
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.ServiceBills, opt => opt.MapFrom(src => src.Service_Bills));
            CreateMap<Room, GetBillByRoomIdDto_Room>();
            CreateMap<Service_Bill, GetBillByRoomIdDto_ServiceBill>();
            
        }

        private static float CalculateAverageRating(Motel motel)
        {
            if (motel.Room_Types == null || !motel.Room_Types.Any()) return 0;

            var validReviews = motel.Room_Types
                .SelectMany(rt => rt.Reviews ?? Enumerable.Empty<Review>())
                .Where(r => r != null);

            return validReviews.Any() ? (float)Math.Round(validReviews.Average(r => r.Rating), 1) : 0;
        }

        private static float CalculateAverageRating(Room_Type roomType)
        {
            if (roomType.Reviews == null || !roomType.Reviews.Any()) return 0;

            var validReviews = roomType.Reviews
                .Where(r => r != null);

            return validReviews.Any() ? (float)Math.Round(validReviews.Average(r => r.Rating), 1) : 0;
        }

        private static int CalculateTotalRooms(Motel motel)
        {
            return motel.Room_Types?
                .SelectMany(rt => rt.Rooms ?? Enumerable.Empty<Room>())
                .Count() ?? 0;
        }
        private static int CalculateTotalRooms(Room_Type roomType)
        {
            return roomType.Rooms?
                .Count() ?? 0;
        }

        private static int CalculateTotalUsers(Motel motel)
        {
            return motel.Room_Types?
                .SelectMany(rt => rt.Rooms ?? Enumerable.Empty<Room>())
                .Sum(r => r.History?.Where(h => h.Status == 1).Count() ?? 0) ?? 0;
        }
        private static int CalculateTotalUsers(Room_Type roomType)
        {
            //tổng số user đã thuê phòng
            return roomType?.Rooms?
                .Sum(r => r.History?.Where(h => h.Status == 1).Count() ?? 0) ?? 0;
        }
        private static int CalculateTotalUsers(Room room)
        {
            return room.History?.Where(h => h.Status == 1).Count() ?? 0;
        }
    }
}
