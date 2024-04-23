using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace RealtyWeb_Server.Controllers
{
    public class CookieAuthenticationEvents: Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
    {
        //private readonly IUsers _users;

        //public CookieAuthenticationEvents(IUsers users)
        //{
        //    _users = users;
        //}

        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var userPrincipal = context.Principal;

            if (userPrincipal?.Identity?.Name?.ToLower() != "admin")
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }
        }
    }
}
