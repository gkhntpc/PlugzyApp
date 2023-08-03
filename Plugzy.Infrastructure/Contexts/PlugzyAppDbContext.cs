using System.Reflection;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.Contexts;

public class PlugzyAppDbContext : IdentityDbContext<User, Role, Guid>
{
    public PlugzyAppDbContext(DbContextOptions<PlugzyAppDbContext> options) : base(options)
    {
    }

    public DbSet<Otp> OTP { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<Socket> Sockets { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Price> Prices { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<County> Counties { get; set; }
    public DbSet<Content> Contents { get; set; }
    public DbSet<Charge> Charges { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
