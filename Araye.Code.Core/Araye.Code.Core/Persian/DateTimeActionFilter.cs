using Microsoft.AspNetCore.Mvc.Filters;

namespace Araye.Code.Core.Persian
{
    public class DateTimeActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture = new PersianCulture();
        }
    }
}