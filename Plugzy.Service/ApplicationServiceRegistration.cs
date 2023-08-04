using System.Reflection;

using MediatR;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Plugzy.Infrastructure;

namespace Plugzy.Service;

public static class ApplicationServiceRegistration 
{
    public static IServiceCollection AddApplicationAndInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructureServices(configuration);

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        
        return services;
    }
}
