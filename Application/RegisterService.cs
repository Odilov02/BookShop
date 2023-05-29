using Application.Mappings;
using Application.Validations;
using Domain.Entities;
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
            return services;
        }
    }
}
