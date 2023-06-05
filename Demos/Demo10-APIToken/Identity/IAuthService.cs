using Demo10_APIToken.Modelo;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo10_APIToken.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> AuthenticateAsync(Guid appRequest, IMemoryCache memoryCache);
        Task<AuthResponse> ValidateAsync(AuthRequest token, IMemoryCache memoryCache);
    }
}
