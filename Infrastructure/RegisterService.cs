using Application.Abstraction;
using Application.Interfaces.ServiceInterfaces;
using Infrastructure.DataAcces;
using Infrastructure.DataAcces.Interceptor;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class RegisterService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Default"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped<IApplicatonDbcontext, AppDbContext>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICommentaryService, CommentarySerivce>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IApplicatonDbcontext, AppDbContext>();
            services.AddScoped<IApplicatonDbcontext, AppDbContext>();
            services.AddScoped<IApplicatonDbcontext, AppDbContext>();
            services.AddScoped<IUserService, UserSevice>();
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IRoleService, RoleService>();

            return services;
        }
    }
}
