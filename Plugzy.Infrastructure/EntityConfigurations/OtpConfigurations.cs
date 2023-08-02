using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Plugzy.Domain.Entities;
namespace Plugzy.Infrastructure.EntityConfigurations
{
    public class OtpConfigurations : IEntityTypeConfiguration<Otp>
    {
        public void Configure(EntityTypeBuilder<Otp> builder)
        {
            builder.Property(b => b.Phone).HasMaxLength(100);
        }
    }
}
