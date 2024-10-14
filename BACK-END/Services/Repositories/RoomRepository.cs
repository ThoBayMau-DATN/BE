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
        public async Task<List<GetAllRoomRepositoryDto>?> GetAllRoomByUser(
            string searchAddress,
            string sortColumn, 
            string sortOrder, 
            int pageNumber, 
            int pageSize)
        {
            

            var query = _db.Room
                .Include(x => x.Motel)
                .ThenInclude(x => x.Price)
                .Include(x => x.Motel)
                .ThenInclude(x => x.User)
                .Include(x => x.Motel)
                .ThenInclude(x => x.Reviews)
                .Include(x => x.Motel)
                .ThenInclude(x => x.Term)
                .Where(x => x.Motel.Status == 1)
                .Where(x => x.Status == 1)
                .AsQueryable();

            //Tìm kiếm
            if (!string.IsNullOrEmpty(searchAddress))
            {
                query = query.Where(x => x.Motel.Address.Contains(searchAddress));
            }

            // Sắp xếp
            if (!string.IsNullOrEmpty(sortColumn))
            {
                query = sortOrder == "desc" 
                    ? query.OrderByDescending(GetSortProperty(sortColumn))
                    : query.OrderBy(GetSortProperty(sortColumn));
            }

            // Áp dụng mapping và phân trang
            var pagedResult = await PagedList<GetAllRoomRepositoryDto>.CreateAsync(
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
                _ => r => r.Id // Mặc định sắp xếp theo Id
            };
        }
    }
}