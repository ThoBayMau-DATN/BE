using AutoMapper;
using BACK_END.Data;
using BACK_END.DTOs.RoomDto;
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

		public async Task<List<GetMotelByAdminDto>> GetNewMotels()
		{
			var newMotels = await _db.Motel
				.Include(m => m.Reviews)    // Load bảng đánh giá
				.Include(m => m.Rooms)      // Load bảng phòng
				.Include(m => m.Prices)     // Load bảng giá
				.Include(m => m.Images)     // Load bảng hình ảnh
				.OrderByDescending(m => m.CreateDate)
				.Take(8)
				.ToListAsync();
			return _mapper.Map<List<GetMotelByAdminDto>>(newMotels);
		}

		public async Task<List<GetMotelByAdminDto>> GetNhaTroNoiBat()
		{
			// Truy vấn LINQ để lấy danh sách 8 nhà trọ nổi bật nhất dựa trên đánh giá
			var topMotels = await _db.Motel
				// Eager loading các bảng liên quan
				.Include(m => m.Reviews)    // Load bảng đánh giá
				.Include(m => m.Rooms)      // Load bảng phòng
				.Include(m => m.Prices)     // Load bảng giá
				.Include(m => m.Images)     // Load bảng hình ảnh
											// Lọc: chỉ lấy những nhà trọ có ít nhất 1 đánh giá
				.Where(m => m.Reviews.Any())
				// Sắp xếp giảm dần theo điểm đánh giá trung bình
				.OrderByDescending(m => m.Reviews.Average(r => r.Rating))
				// Giới hạn kết quả: chỉ lấy 8 nhà trọ đầu tiên
				.Take(8)
				// Thực thi query và chuyển kết quả thành List
				.ToListAsync();
			// Chuyển đổi từ entity Motel sang DTO trước khi trả về
			return _mapper.Map<List<GetMotelByAdminDto>>(topMotels);
		}
	}
}
