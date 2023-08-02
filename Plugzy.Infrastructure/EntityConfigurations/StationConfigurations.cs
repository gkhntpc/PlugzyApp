using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations
{
    public class StationConfigurations : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(100);
            builder.Property(s => s.Number).HasMaxLength(100);
            builder.Property(s => s.Address).HasMaxLength(200);
            builder.Property(s => s.Latitude).HasMaxLength(200);
            builder.Property(s => s.Longitude).HasMaxLength(200);
        }
    }
}
