using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations
{
    public class CountyConfigurations : IEntityTypeConfiguration<County>
    {
        public void Configure(EntityTypeBuilder<County> builder)
        {
            builder.Property(b => b.Name).HasMaxLength(100);
        }
    }
}
