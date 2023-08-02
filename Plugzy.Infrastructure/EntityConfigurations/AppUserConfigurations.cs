using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations
{
    public class AppUserConfigurations : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(b => b.PhoneNumber).HasMaxLength(100);
            builder.Property(b => b.Email).HasMaxLength(100);
            builder.Property(b => b.FullName).HasMaxLength(100);

        }
    }
}
