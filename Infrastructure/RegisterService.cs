using Application.Abstraction;
using Application.Interfaces.ServiceInterfaces;
using Infrastructure.DataAcces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddScoped<ICommentaryService, CommentaryService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IApplicatonDbcontext, AppDbContext>();
            services.AddScoped<IApplicatonDbcontext, AppDbContext>();
            services.AddScoped<IApplicatonDbcontext, AppDbContext>();
            return services;
        }
    }
}
