using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.EntityConfigurations
{
    public class SocketConfigurations : IEntityTypeConfiguration<Socket>
    {
        public void Configure(EntityTypeBuilder<Socket> builder)
        {
            builder.Property(s => s.Number).HasMaxLength(100);
            builder.Property(s => s.Kw).HasColumnType("decimal(19, 2)");
            builder.Property(s => s.Price).HasColumnType("decimal(19, 2)");
        }
    }
}
