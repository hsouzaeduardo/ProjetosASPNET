using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Demo10_03
{
    public class CustomAuth
    {
        public static bool ValidaUser(HttpContext  context, string claim, string value)
        {
            return context.User.Identity.IsAuthenticated &&
                context.User.Claims.Any(x => x.Type == claim && x.Value.Contains(value));
        }
    }

    public class ClaimAuth : TypeFilterAttribute
    {
        public ClaimAuth(string claim, string valor):base(typeof(RequestFilter))
        {
            Arguments = new object[] { new Claim(claim, valor) };
        }
    }

    public class RequestFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequestFilter(Claim claim)
        {
            _claim = claim;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new
                    {
                        area = "Identity",
                        page = "/Account/Login",
                        ReturnUrl = context.HttpContext.Request.Path.ToString()
                    }
                    )); ;

                return;
            }
            if(!CustomAuth.ValidaUser(context.HttpContext, _claim.Type, _claim.Value))
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
