using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Contexts;

namespace Plugzy.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PlugzyAppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Development"));
        });
        services.AddIdentity<User, Role>().AddEntityFrameworkStores<PlugzyAppDbContext>();

        return services;
    }
}
