using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Contexts;
using Plugzy.Infrastructure.Services.JwtService;

namespace Plugzy.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PlugzyAppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
        services.AddIdentity<User, Role>()
            .AddEntityFrameworkStores<PlugzyAppDbContext>()
            .AddTokenProvider(configuration["ProviderName"], typeof(DataProtectorTokenProvider<User>));

        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}
