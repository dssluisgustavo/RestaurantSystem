using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Restaurant_System
{
    public class AdminAuth : TypeFilterAttribute
    {
        public AdminAuth() : base(typeof(AdminAuthFilter)) { }
    }

    public class AdminAuthFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var jwtToken = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            TokenService tokenService = new TokenService();
            var securityToken = tokenService.ReadToken(jwtToken);
            
            var isAdminClaim = securityToken.Claims.FirstOrDefault(_ => _.Type == "isAdmin");

            if(!Convert.ToBoolean(isAdminClaim.Value))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
