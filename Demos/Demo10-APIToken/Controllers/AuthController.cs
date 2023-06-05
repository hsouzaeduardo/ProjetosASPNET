using Demo10_APIToken.Identity;
using Demo10_APIToken.Modelo;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo10_APIToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authenticationService;
        private readonly IMemoryCache _memoryCache;
        public AuthController(IAuthService authenticationService, IMemoryCache memoryCache)
        {
            _authenticationService = authenticationService;
            _memoryCache = memoryCache;
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<AuthResponse>> AuthenticateAsync(string request)
        {
            Guid guid = Guid.Parse(request);
            //Validação Guid para Applicação ou produto
            return Ok(await _authenticationService.AuthenticateAsync(guid, _memoryCache)); ;
        }

        [HttpPost("validate")]
        public async Task<ActionResult> ValidateAsync(AuthRequest request)
        {
            var response = await _authenticationService.ValidateAsync(request, _memoryCache);

            if (response != null)
                return Ok(response);
            else
                return Unauthorized("Invalid Token");
        }
    }
}
