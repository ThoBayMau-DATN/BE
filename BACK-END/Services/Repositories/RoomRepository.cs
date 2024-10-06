using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACK_END.Data;
using BACK_END.DTOs.RoomDto;
using BACK_END.Mappers;
using BACK_END.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class RoomRepository : IRoom
    {
        private readonly BACK_ENDContext _db;
        public RoomRepository(BACK_ENDContext db)
        {
            _db = db;
        }
        public async Task<List<GetAllRoomRepository>?> GetAllRoom()
        {
            var listRoom = await _db.Room
                .Include(x => x.BoardingHouse)
                .ThenInclude(x => x.User)
                .Include(x => x.RoomType)
                .Select(x => x.MapToGetAllRoomRepository())
                .ToListAsync();
            return listRoom;
        }
    }
}