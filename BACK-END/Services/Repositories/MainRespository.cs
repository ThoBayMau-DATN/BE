using AutoMapper;
using BACK_END.Data;
using BACK_END.DTOs.MainDto;
using BACK_END.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class MainRespository : IGetTro
	{
		private readonly BACK_ENDContext _db;
		private readonly FirebaseStorageService _firebaseStorageService;
		private readonly IMapper _mapper;
		public MainRespository(BACK_ENDContext db, FirebaseStorageService firebaseStorageService, IMapper mapper)
		{
			_db = db;
			_firebaseStorageService = firebaseStorageService;
			_mapper = mapper;
		}

        public async Task<IEnumerable<MotelDTO>> GetHighlightedMotelsAsync()
        {
            return await _db.Motel
                .Include(m => m.User)
                .Include(m => m.Room_Types)
                    .ThenInclude(rt => rt.Images)
                .Where(m => _db.Package_User.Any(pu => pu.UserId == m.UserId)) // Điều kiện trọ nổi bật
                .Select(m => new MotelDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Address = m.Address,
                    RoomTypes = m.Room_Types.Select(rt => new RoomTypeDTO
                    {
                        Id = rt.Id,
                        Price = rt.Price,
                        Images = rt.Images.Select(img => new ImageDTO
                        {
                            Id = img.Id,
                            Link = img.Link,
                            Type = img.Type
                        }).ToList()
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<MotelDTO>> GetNewMotelsAsync()
        {
            var threeMonthsAgo = DateTime.Now.AddMonths(-3);

            return await _db.Motel
                .Include(m => m.Room_Types)
                    .ThenInclude(rt => rt.Images)
                .Where(m => m.CreateDate >= threeMonthsAgo)
                .OrderByDescending(m => m.CreateDate)
                .Select(m => new MotelDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    Address = m.Address,
                    RoomTypes = m.Room_Types.Select(rt => new RoomTypeDTO
                    {
                        Id = rt.Id,
                        Price = rt.Price,
                        Images = rt.Images.Select(img => new ImageDTO
                        {
                            Id = img.Id,
                            Link = img.Link,
                            Type = img.Type
                        }).ToList()
                    }).ToList()
                })
                .ToListAsync();
        }
    }
}
