using Application.Abstraction;
using Application.Interfaces.ServiceInterfaces;
using Infrastructure.DataAcces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class RegisterService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Default")));
            services.AddScoped<IApplicatonDbcontext, AppDbContext>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICommentaryService, CommentarySerivce>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IApplicatonDbcontext, AppDbContext>();
            services.AddScoped<IApplicatonDbcontext, AppDbContext>();
            services.AddScoped<IApplicatonDbcontext, AppDbContext>();
            return services;
        }
    }
}
