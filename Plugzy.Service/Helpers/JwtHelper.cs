using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Plugzy.Domain.Entities;
using Plugzy.Models.Response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Plugzy.Service.Helpers
{
    public class JwtHelper : IJwtHelper
    {
        public readonly IConfiguration _config;
        public TokenOptions _tokenOptions;
        public JwtHelper(IConfiguration config)
        {
            _config = config;
            _tokenOptions = _config.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AuthResponse CreateToken(AppUser appUser)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.SecurityKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

            var jwtSecurtityToken = new JwtSecurityToken(
                issuer: _tokenOptions.Issuer,
                audience: _tokenOptions.Audience,
                claims: SetClaim(appUser),
                expires: DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration),
                notBefore: DateTime.Now,
                signingCredentials: signingCredentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurtityToken);
            return new AuthResponse
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken()
            };
        }
        private IEnumerable<Claim> SetClaim(AppUser user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim("Name", user.PhoneNumber));
            claims.Add(new Claim("Id", user.Id.ToString()));
            return claims;
        }
        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}
    