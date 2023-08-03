using Microsoft.AspNetCore.Identity;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.Services.JwtService;

public interface IJwtService 
{
    string CreateAccessToken(User user);
    string CreateRefreshToken();
    Task<string> CreateAndRegisterRefreshToken(User user, UserManager<User> userManager);
}
