using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using BACK_END.Services.Repositories;

namespace BACK_END.Data
{
	public static class DependencyInjection
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IAuth, AuthRepository>();
			services.AddScoped<TokenService>();
			services.AddScoped<IRoom, RoomRepository>();
		}
	}
}
