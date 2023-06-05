using Demo10_APIToken.Modelo;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo10_APIToken.Identity
{
    public class AuthService : IAuthService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;

        }

        public async Task<AuthResponse> AuthenticateAsync(Guid request, IMemoryCache memoryCache)
        {
            AuthResponse response = null;

            if (!memoryCache.TryGetValue(request, out response))
            {

                JwtSecurityToken jwtSecurityToken = await GenerateToken(request); ;

                var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

                response = new AuthResponse
                {
                    Token = token,
                    AppId = request.ToString(),
                    Expiration = _jwtSettings.DurationInMinutes * 60,
                    Expirationate = jwtSecurityToken.ValidTo
                };

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(_jwtSettings.DurationInMinutes));

                memoryCache.Set(request, response, cacheEntryOptions);
            }

            return response;
        }

        public async Task<AuthResponse> ValidateAsync(AuthRequest request, IMemoryCache memoryCache)
        {
            string tokenCache;

            AuthResponse response = null;

            if (memoryCache.TryGetValue(request.App, out response))
            {
                if (!response.Token.Equals(request.Token))
                    response = null;
                else
                    response.Expiration = Math.Round((response.Expirationate - DateTime.UtcNow).TotalSeconds);
            }

            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(Guid userApp)
        {
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
