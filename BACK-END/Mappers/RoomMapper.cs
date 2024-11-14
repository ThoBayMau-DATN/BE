//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using BACK_END.DTOs.RoomDto;
//using BACK_END.Models;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

//namespace BACK_END.Mappers
//{
//    public static class RoomMapper
//    {
//        /*public static GetAllRoomRepositoryDto MapToGetAllRoomRepository(this Room model)
//        {
//            var room = new GetAllRoomRepositoryDto
//            {
//                Id = model.Id,
//                Price = model.Price,
//                Rating = (model.Motel?.Reviews?.Count > 0 ? (model.Motel.Reviews.Average(x => x.Rating)) : 0),
//                TotalRating = model.Motel?.Reviews?.Count ?? 0,
//                Motel = new DTOs.RoomDto.ModelDto
//                {
//                    NameOwner = model.Motel?.Name ?? "",
//                    Address = model.Motel?.Address ?? "",
//                    Location = model.Motel?.Location ?? "",
//                    TotalRoom = model.Motel?.Rooms?.Count ?? 0
//                }
//            };

//            foreach (var item in model?.Motel?.Prices)
//            {
//                if (item != null && item.IsActive == true)
//                {
//                    room.PriceOther = new DTOs.RoomDto.PriceDto
//                    {
//                        Electric = item?.Electric ?? 0.00,
//                        Water = item?.Water ?? 0.00,
//                        Other = item?.Other ?? 0.00
//                    };
//                }
//            }
//            return room;
//        }*/
//        /*public static GetAllMotelByAdminDto MapToGetAllMotelByAdmin(this Motel model)
//        {
//            return new GetAllMotelByAdminDto
//            {
//                Id = model.Id,
//                Name = model.Name,
//                Address = model.Address,
//                CreateDate = model.CreateDate,
//                TotalRoom = model?.Rooms?.Count ?? 0,
//                Status = model?.Status ?? 0,
//                Images = model?.Images?.Where(x => x.Link != null).Select(x => x.Link!).ToList(),
//                Owner = model?.User != null ? new GetOwnerDto
//                {
//                    Id = model.User?.Id ?? 0,
//                    FullName = model.User?.FullName ?? ""
//                } : null,
//                Price = model?.Prices?.Where(x => x.IsActive == true).Select(x => new GetAllMotelByAdminPriceDto
//                {
//                    Id = x.Id,
//                    Water = x?.Water ?? 0,
//                    Electric = x?.Electric ?? 0,
//                    Other = x?.Other ?? 0
//                }).FirstOrDefault(),

//            };
//        }*/

//        public static (Motel motel, List<Room> ListRoom, Price price) MapToMotelAndRoom(this AddMotelAndRoomDto dto)
//        {
//            var motel = new Motel
//            {
//                Name = dto.Name,
//                Address = dto.Address,
//                UserId = dto.UserId,
//                Status = 1,
//                CreateDate = DateTime.Now
//            };


//            var ListRoom = new List<Room>();
//            for(int i = 0; i < dto.TotalRoom; i++)
//            {
//                ListRoom.Add(new Room{
//                    RoomNumber = i + 1,
//                    Area = dto.Area,
//                    Price = dto.PriceRoom,
//                    Status = 1
//                });
//            }

//            var price = new Price
//            {
//                Water = dto.PriceWater,
//                Electric = dto.PriceElectric,
//                Other = dto.PriceOther,
//                MotelId = motel.Id
//            };

//            return (motel, ListRoom, price);
//        }
//        public static (Motel motel, Price price) MapToMotelAndPrice(this UpdateMotelDto dto)
//        {
//            var motel = new Motel
//            {
//                Name = dto.Name,
//                Address = dto.Address,
//            };

//            var price = new Price
//            {
//                Water = dto?.Water ?? 0,
//                Electric = dto?.Electric ?? 0,
//                Other = dto?.Other ?? 0
//            };

//            return (motel, price);
//        }
//        public static GetRoomByMotelIdDto MapToGetRoomByMotelIdDto(this Room room)
//        {
//            return new GetRoomByMotelIdDto
//            {
//                Id = room.Id,
//                RoomNumber = room.RoomNumber,
//                Area = room.Area,
//                UserFromRoom = room.Users?.Count ?? 0,
//                Price = room.Price,
//                Status = room.Status
//            };
//        }
//        /*public static ImageDto MapToImageDto(this Image image)
//        {
//            return new ImageDto
//            {
//                Id = image.Id,
//                Link = image.Link ?? ""
//            };
//        }*/
//    }
//}
