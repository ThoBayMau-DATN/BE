using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BACK_END.DTOs.RoomDto;

namespace BACK_END.Services.Interfaces
{
    public interface IRoom
    {
        Task<List<GetAllRoomRepositoryDto>?> GetAllRoomByUser(string searchAddress,string sortColumn, string sortOrder, int pageNumber, int pageSize);
    }
}