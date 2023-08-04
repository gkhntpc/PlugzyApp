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
        public DbSet<Content> Contents { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>().Property(x => x.PhoneNumber).HasMaxLength(100);
            builder.Entity<AppUser>().Property(x => x.Email).HasMaxLength(100);
            builder.Entity<Socket>().Property(x => x.Kw).HasColumnType("decimal(19,2)");
            builder.Entity<Socket>().Property(x => x.Price).HasColumnType("decimal(19,2)");
            base.OnModelCreating(builder);
        }
    }
    
}
