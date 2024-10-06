using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BACK_END.Data;
using BACK_END.DTOs.RoomDto;
using BACK_END.Mappers;
using BACK_END.Models;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
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
        public async Task<List<GetAllRoomRepository>?> GetAllRoom(
            string searchAddress,
            string sortColumn, 
            string sortOrder, 
            int pageNumber, 
            int pageSize)
        {
            

            var query = _db.Room
                .Include(x => x.BoardingHouse)
                .ThenInclude(x => x.User)
                .Include(x => x.RoomType)
                .AsQueryable();

            //Tìm kiếm
            if (!string.IsNullOrEmpty(searchAddress))
            {
                query = query.Where(x => x.BoardingHouse.Address.Contains(searchAddress));
            }

            // Sắp xếp
            if (!string.IsNullOrEmpty(sortColumn))
            {
                query = sortOrder == "desc" 
                    ? query.OrderByDescending(GetSortProperty(sortColumn))
                    : query.OrderBy(GetSortProperty(sortColumn));
            }

            // Áp dụng mapping và phân trang
            var pagedResult = await PagedList<GetAllRoomRepository>.CreateAsync(
                query.Select(x => x.MapToGetAllRoomRepository()),
                pageNumber,
                pageSize);

            return pagedResult;
        }

        private Expression<Func<Room, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "area" => r => r.Area,
                "price" => r => r.Price,
                "quantity" => r => r.Quantity,
                _ => r => r.Id // Mặc định sắp xếp theo Id
            };
        }
    }
}