using BACK_END.Services;
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
            services.AddScoped<INoti, NofRespository>();
            services.AddScoped<IStatictical, StaticticalRepository>();
            services.AddScoped<IUser, UserRepository>();
            services.AddScoped<ITicket, TicketRepository>();
            services.AddScoped<FirebaseStorageService>();
            services.AddScoped<IHome, HomeRespository>();
            services.AddScoped<IRole, RoleRepository>();
            services.AddScoped<IService, ServiceRepository>();
            services.AddScoped<IGetTro, MainRespository>();
            services.AddSingleton<IVnPayService, VnPayService>();
            services.AddScoped<IPackage, PackageRepository>();
        }
    }
}
