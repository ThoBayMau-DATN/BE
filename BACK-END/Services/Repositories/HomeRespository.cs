using BACK_END.Data;
using BACK_END.DTOs.Count;
using BACK_END.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BACK_END.Services.Repositories
{
    public class HomeRespository : IHome
    {
        private readonly BACK_ENDContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeRespository(BACK_ENDContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        public async Task<List<CountDtos>> CountHomePage()
        {
            /*
			* Phương thức này thực hiện việc đếm các số liệu cần thiết cho trang chủ. Nó gọi tuần tự ba phương thức con:
			* - CountMotel() để đếm số lượng nhà trọ.
			* - CountUsersByRole("CUSTOMER", "Khách hàng") để đếm số lượng người dùng có vai trò là "Khách hàng".
			* - CountUsersByRole("MOTEL", "Chủ trọ") để đếm số lượng người dùng có vai trò là "Chủ trọ".
			* + Mỗi phương thức con sẽ trả về một đối tượng CountDtos (chứa tiêu đề và giá trị đếm), sau đó kết quả được thêm vào danh sách res
			*/
            List<CountDtos> res = new List<CountDtos>();

            res.Add(await CountMotel());
            res.Add(await CountUsersByRole("CUSTOMER", "Khách hàng"));
            res.Add(await CountUsersByRole("MOTEL", "Chủ trọ"));

            return res;
        }

        private async Task<CountDtos> CountMotel()
        {
            /*
			 * Đếm số lượng nhà trọ trong cơ sở dữ liệu.
			 * await _context.Room.CountAsync() đếm tổng số bản ghi (số lượng nhà trọ) trong bảng Room của cơ sở dữ liệu
			 * Kết quả (số lượng nhà trọ) được gán vào Value của đối tượng CountDtos.
			 * Title được đặt là "Nhà trọ".
			 * Trả về đối tượng CountDtos với tiêu đề và giá trị.
			 */
            var value = await _context.Room.CountAsync();

            return new CountDtos
            {
                Title = "Nhà trọ",
                Value = value
            };
        }

        // Phương thức chung để đếm số người dùng theo role
        private async Task<CountDtos> CountUsersByRole(string roleName, string title)
        {
            /*
			 * Đếm số lượng người dùng thuộc một vai trò cụ thể.
			 * usersInRole.Count trả về số lượng người dùng trong danh sách.
			 * - Phương thức nhận vào hai tham số:
			 * + roleName: tên vai trò cần đếm (ví dụ: "CUSTOMER" hoặc "MOTEL").
			 * + title: tiêu đề hiển thị cho kết quả (ví dụ: "Khách hàng" hoặc "Chủ trọ").
			 * Tạo một đối tượng CountDtos với Title là title và Value là số lượng người dùng trong vai trò đó, rồi trả về đối tượng này.
			 */
            var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);

            return new CountDtos
            {
                Title = title,
                Value = usersInRole.Count
            };
        }
    }
}
