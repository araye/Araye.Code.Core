using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

namespace Araye.Code.Core.Security
{
    public class ArayeAuthorizationAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var context = filterContext.HttpContext;

            if (filterContext.ActionDescriptor.FilterDescriptors.Any(x => x.Filter is AllowAnonymousAttribute))
                return;

            if (context.User != null && context.User.IsInRole(Consts.WebAdminRoleName))
                return;

            var atts = filterContext.ActionDescriptor.EndpointMetadata.Where(ac => ac.GetType() == typeof(ArayeActionPermissionAttribute)).Select(a => (ArayeActionPermissionAttribute)a);
            var permission = false;
            foreach (var att in atts)
            {
                permission = HasPermission(context, att.ActionId.ToLower().Trim());
                if (permission)
                    break;
            }

            if (!permission && atts.Any())
            {
                filterContext.Result = new UnauthorizedResult();
            }
        }

        private static bool HasPermission(HttpContext context, string actionId)
        {
            var identity = (ClaimsIdentity)context.User.Identity;
            var accessClaim = identity.FindFirst(Consts.PermissionAccessClaimTitle);
            if (accessClaim == null || accessClaim.Value.Length <= 0) return false;
            return accessClaim.Value.Split(',').Contains(actionId);
        }

    }
}
