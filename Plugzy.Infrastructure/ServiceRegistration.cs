using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Context;
using Plugzy.Infrastructure.Interface.Repository;
using Plugzy.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Plugzy.Infrastructure
{
    //    builder.Services.AddDbContext<PlugzyDbContext>(options =>
    //{
    //    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
    //});
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<PlugzyDbContext>(options =>
                    options.UseSqlServer(configuration["ConnectionStrings:SqlServerConnectionString"]));

            serviceCollection.AddIdentity<AppUser, IdentityRole<Guid>>(opt =>
            {

            }).AddEntityFrameworkStores<PlugzyDbContext>();

            serviceCollection.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
        }
    }
}
