using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Models
{
    public static class ServiceRegistraion
    {
        public static void AddModels(this IServiceCollection serviceCollection)
        {
            var assm = Assembly.GetExecutingAssembly();
            serviceCollection.AddAutoMapper(assm);
            serviceCollection.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(assm));
        }
    }
}
