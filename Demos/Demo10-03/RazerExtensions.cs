using Microsoft.AspNetCore.Mvc.Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo10_03
{
    public static class RazerExtensions
    {
        public static bool IfHasClaim(this RazorPage page, string claim, string value)
        {
            return CustomAuth.ValidaUser(page.Context, claim, value);
        }

        public static string IfHasClaimShow(this RazorPage page, string claim, string value)
        {
            return CustomAuth.ValidaUser(page.Context, claim, value) ? "": "disabled";
        }

    }
}
