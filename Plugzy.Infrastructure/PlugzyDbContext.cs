using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure
{
    public class PlugzyDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public PlugzyDbContext(DbContextOptions<PlugzyDbContext> options) : base(options) { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Otp> Otps { get; set; }
        public DbSet<Socket> Sockets { get; set; }
        public DbSet<Station> Stations { get; set; }
       
    }
}
