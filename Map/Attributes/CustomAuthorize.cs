using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Map.Attributes
{
    public class CustomAuthorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var claim = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "userId");
            if (claim == null)
            {
                context.Result = new RedirectResult("/Admin/Register");
            }
        }
    }
}
