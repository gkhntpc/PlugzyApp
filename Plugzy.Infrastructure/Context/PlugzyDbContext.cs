using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plugzy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugzy.Infrastructure.Context
{
    public class PlugzyDbContext : IdentityDbContext<AppUser,IdentityRole<Guid>,Guid>
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Otp> Otps { get; set; }
        public PlugzyDbContext(DbContextOptions<PlugzyDbContext> options) : base(options) { }


    }
}
