using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Contexts;
using Plugzy.Infrastructure.Repositories.Base;
using Plugzy.Infrastructure.Repositories.Contracts;

namespace Plugzy.Infrastructure.Repositories;

public class OtpRepository : EfRepositoryBase<Otp, PlugzyAppDbContext>, IOtpRepository
{
    public OtpRepository(PlugzyAppDbContext context) : base(context)
    {
    }
}
