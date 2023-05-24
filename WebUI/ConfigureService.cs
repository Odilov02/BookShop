namespace WebUI
{
    public static class ConfigureService
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
