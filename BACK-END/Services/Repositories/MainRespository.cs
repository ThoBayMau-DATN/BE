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

        public async Task<IEnumerable<RoomTypeWithPackageDTO>> GetRoomTypesWithFeature()
        {
            var roomTypes = await _db.Room_Type
                .Include(r => r.Motel) 
                .Include(r => r.Images)
                .ToListAsync();

            var result = roomTypes.Select(roomType => new RoomTypeWithPackageDTO
            {
                Id = roomType.Id,
                Price = roomType.Price,
                Name = roomType.Name,
                Address = roomType.Motel?.Address,
                Images = roomType.Images?.Select(i => new ImageDTO
                {
                    Id = i.Id,
                    Link = i.Link,
                    Type = i.Type
                }).ToList(),
                IsFeatured = _db.Package_User.Any(pu => pu.UserId == roomType.Motel.UserId)
            }).Where(r => r.IsFeatured)
              .ToList();

            return result;
        }
        public async Task<List<RoomTypeWithPackageDTO>> GetNewRoomTypesAsync()
        {
            var recentDate = DateTime.Now.AddMonths(-3);
            var roomTypes = await _db.Room_Type
                .Include(rt => rt.Motel)
                .Include(rt => rt.Images)
                .Where(rt => rt.Motel.CreateDate >= recentDate).OrderByDescending(rt => rt.Motel.CreateDate)
                .Select(rt => new RoomTypeWithPackageDTO
                {
                    Id = rt.Id,
                    Name = rt.Name,
                    Price = rt.Price,
                    Address = rt.Motel.Address,
                    Images = rt.Images.Select(i => new ImageDTO
                    {
                        Id = i.Id,
                        Link = i.Link,
                        Type = i.Type
                    }).ToList(),
                })
                .ToListAsync();

            return roomTypes;
        }

        public async Task<List<RoomTypeWithPackageDTO>> GetRoomTypesUnderOneMillionAsync()
        {
            var roomTypes = await _db.Room_Type
        .Include(rt => rt.Motel)
        .Include(rt => rt.Images)
        .Where(rt => rt.Price < 1000000)
        .OrderByDescending(rt => rt.Motel.CreateDate)
        .Select(rt => new RoomTypeWithPackageDTO
        {
            Id = rt.Id,
            Name = rt.Name,
            Price = rt.Price,
            Address = rt.Motel.Address,
            Images = rt.Images.Select(i => new ImageDTO
            {
                Id = i.Id,
                Link = i.Link,
                Type = i.Type
            }).ToList(),
        })
        .ToListAsync();

            return roomTypes;
        }
    }
}
