using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class RegisterService
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
    {

        return services;
    }
}
