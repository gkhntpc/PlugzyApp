using Microsoft.Extensions.DependencyInjection;
using Plugzy.Service.Helpers;
using Plugzy.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Service
{
    public static class ServiceRegistration
    {
        public static void AddService(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
            serviceCollection.AddScoped<IJwtHelper, JwtHelper>();

        }
    }
}
