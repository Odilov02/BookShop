using Application.Interfaces.ServiceInterfaces;
using WebUI.Services;

namespace WebUI
{
    public static class ConfigureService
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
