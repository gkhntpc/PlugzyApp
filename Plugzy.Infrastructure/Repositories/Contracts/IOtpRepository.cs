using Plugzy.Domain.Entities;
using Plugzy.Infrastructure.Repositories.Base.Contracts;

namespace Plugzy.Infrastructure.Repositories.Contracts;

public interface IOtpRepository : IAsyncRepository<Otp>, IRepository<Otp>
{
}
