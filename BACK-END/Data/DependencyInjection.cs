using BACK_END.Models;
using BACK_END.Services.Interfaces;
using BACK_END.Services.MyServices;
using BACK_END.Services.Repositories;
using Microsoft.AspNetCore.Identity;

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
        }
    }
}
