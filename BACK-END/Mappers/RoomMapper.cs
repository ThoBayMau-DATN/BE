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
//        public static GetAllRoomRepositoryDto MapToGetAllRoomRepository(this Room model)
//        {
//            var room = new GetAllRoomRepositoryDto
//            {
//                Id = model.Id,
//                Area = model.Area,
//                Price = model.Price,
//                Rating = (model.Motel?.Reviews?.Count > 0 ? (model.Motel.Reviews.Average(x => x.Rating)) : 0),
//                TotalRating = model.Motel?.Reviews?.Count ?? 0,
//                LinkTerm = model.Motel?.Term?.Link ?? "",
//                Motel = new DTOs.RoomDto.ModelDto
//                {
//                    NameOwner = model.Motel?.Name ?? "",
//                    Address = model.Motel?.Address ?? "",
//                    Location = model.Motel?.Location ?? "",
//                    TotalRoom = model.Motel?.TotalRoom ?? 0
//                }
//            };

//            if (model.Motel?.Price != null && model.Motel?.Price?.IsActive == true)
//            {
//                room.PriceOther = new DTOs.RoomDto.PriceDto
//                {
//                    Electric = model.Motel?.Price?.Electric ?? 0.00,
//                    Water = model.Motel?.Price?.Water ?? 0.00,
//                    Other = model.Motel?.Price?.Other ?? 0.00
//                };
//            }
//            return room;
//        }
//    }
//}