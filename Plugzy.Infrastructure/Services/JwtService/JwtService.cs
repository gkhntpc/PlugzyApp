using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using Plugzy.Domain.Entities;

namespace Plugzy.Infrastructure.Services.JwtService;

public class JwtService : IJwtService
{
    private readonly IConfiguration _configuration;

    public JwtService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string CreateAccessToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
        };

        SigningCredentials signingCredentials = new(
            key: new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenOptions:SecurityKey"])),
            algorithm: SecurityAlgorithms.HmacSha512Signature
        );

        JwtSecurityToken securityToken = new(
            issuer: _configuration["TokenOptions:Issuer"],
            audience: _configuration["TokenOptions:Audience"],
            expires: DateTime.Now.AddHours(Int32.Parse(_configuration["TokenOptions:AccessTokenExpiration"])),
            notBefore: DateTime.Now,
            claims: claims,
            signingCredentials: signingCredentials
        );

        JwtSecurityTokenHandler tokenHandler = new();

        string token = tokenHandler.WriteToken(securityToken);

        return token;
    }

    public string CreateRefreshToken() => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));

    public async Task<string> CreateAndRegisterRefreshToken(User user, UserManager<User> userManager)
    {
        string token = CreateRefreshToken();
        // Remove old refresh token if exists
        await userManager.RemoveAuthenticationTokenAsync(user, _configuration["ProviderName"], "RefreshToken");
        // Register created refresh token
        await userManager.SetAuthenticationTokenAsync(user, _configuration["ProviderName"], "RefreshToken", token);

        return token;
    }
}
