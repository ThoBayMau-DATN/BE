using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACK_END.DTOs.RoomDto;
using BACK_END.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BACK_END.Mappers
{
    public static class RoomMapper
    {
        /*public static GetAllRoomRepositoryDto MapToGetAllRoomRepository(this Room model)
        {
            var room = new GetAllRoomRepositoryDto
            {
                Id = model.Id,
                Price = model.Price,
                Rating = (model.Motel?.Reviews?.Count > 0 ? (model.Motel.Reviews.Average(x => x.Rating)) : 0),
                TotalRating = model.Motel?.Reviews?.Count ?? 0,
                Motel = new DTOs.RoomDto.ModelDto
                {
                    NameOwner = model.Motel?.Name ?? "",
                    Address = model.Motel?.Address ?? "",
                    Location = model.Motel?.Location ?? "",
                    TotalRoom = model.Motel?.Rooms?.Count ?? 0
                }
            };

            foreach (var item in model?.Motel?.Prices)
            {
                if (item != null && item.IsActive == true)
                {
                    room.PriceOther = new DTOs.RoomDto.PriceDto
                    {
                        Electric = item?.Electric ?? 0.00,
                        Water = item?.Water ?? 0.00,
                        Other = item?.Other ?? 0.00
                    };
                }
            }
            return room;
        }*/
        /*public static GetAllMotelByAdminDto MapToGetAllMotelByAdmin(this Motel model)
        {
            return new GetAllMotelByAdminDto
            {
                Id = model.Id,
                Name = model.Name,
                Address = model.Address,
                CreateDate = model.CreateDate,
                TotalRoom = model?.Rooms?.Count ?? 0,
                Status = model?.Status ?? 0,
                Images = model?.Images?.Where(x => x.Link != null).Select(x => x.Link!).ToList(),
                Owner = model?.User != null ? new GetOwnerDto
                {
                    Id = model.User?.Id ?? 0,
                    FullName = model.User?.FullName ?? ""
                } : null,
                Price = model?.Prices?.Where(x => x.IsActive == true).Select(x => new GetAllMotelByAdminPriceDto
                {
                    Id = x.Id,
                    Water = x?.Water ?? 0,
                    Electric = x?.Electric ?? 0,
                    Other = x?.Other ?? 0
                }).FirstOrDefault(),

            };
        }*/

        public static (Motel motels, List<Room> rooms, Room_Type roomType, List<Service>? services) MapToAddMotel(this AddMotelDto dto)
        {
            var motels = new Motel
            {
                Name = dto.Name,
                Address = dto.Address,
                Description = dto.Description,
                Location = dto.Location,
                Status = 1,
                CreateDate = DateTime.Now,
                UserId = dto.OwnerId
            };

            var roomType = new Room_Type
            {
                Name = dto.NameRoomType,
                Description = dto.DescriptionRoomType,
                Area = dto.Area,
                Price = dto.Price,
            };


            var rooms = new List<Room>();
            for (int i = 0; i < dto.QuantityRoom; i++)
            {
                rooms.Add(new Room
                {
                    RoomNumber = i + 1,
                    Status = 1,
                });
            }

            List<Service>? services = null;
            if (dto.Services != null)
            {
                services = new List<Service>();
                foreach (var item in dto.Services)
                {
                    services.Add(new Service
                    {
                        Name = item.Name,
                        Description = item.Description,
                        Price = item.Price,
                    });
                }

            }



            return (motels, rooms, roomType, services);
        }

        public static (Room_Type roomType, List<Room> rooms) MapToAddRoomType(this AddRoomTypeDto dto)
        {
            var roomType = new Room_Type
            {
                Name = dto.Name,
                Description = dto.Description,
                Area = dto.Area,
                Price = dto.Price,
            };

            var rooms = new List<Room>();
            for (int i = 0; i < dto.QuantityRoom; i++)
            {
                rooms.Add(new Room
                {
                    RoomNumber = i + 1,
                    Status = 1,
                });
            }

            return (roomType, rooms);
        }
        

        public static GetPriceByRoomTypeIdDto MapToGetPriceByRoomTypeIdDto(this Room_Type roomType)
        {
            return new GetPriceByRoomTypeIdDto
            {
                RoomTypeId = roomType?.Id ?? 0,
                Price = roomType?.Price ?? 0,
                Price_Electric = roomType?.Motel?.Services?.Where(x => x.Name == "Điện").FirstOrDefault()?.Price ?? 0,
                Price_Water = roomType?.Motel?.Services?.Where(x => x.Name == "Nước").FirstOrDefault()?.Price ?? 0,
            };
        }
    }
}
