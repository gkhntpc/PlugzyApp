using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations
{
    public class FavoriteConfigurations : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.Property(b => b.UserId).IsRequired();
            builder.Property(b => b.StationId).IsRequired();
        }
    }
}
