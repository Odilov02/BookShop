using Application.Mappings;
using Application.Validations;
using Domain.Entities;
using Domain.Entities.IdentityEntities;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class RegisterService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(MapProfile));
            services.AddScoped<IValidator<User>, UserValidation>();
            services.AddScoped<IValidator<Author>, AuthorValidation>();
            services.AddScoped<IValidator<Book>, BookValidation>();
            services.AddScoped<IValidator<Role>, RoleValidation>();
            services.AddScoped<IValidator<Commentary>, CommentaryValidation>();
            services.AddScoped<IValidator<Category>, CategoryValidation>();
            services.AddScoped<IValidator<Permission>, PermissionValidation>();

            return services;
        }
    }
}
