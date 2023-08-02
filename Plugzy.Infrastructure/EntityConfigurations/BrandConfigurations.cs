using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations
{
    public class BrandConfigurations : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100);
            builder.Property(b => b.Logo).HasMaxLength(200);
        }
    }
}
