using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Bakery_Project.BAL
{
    public class CheckAccess : ActionFilterAttribute, IAuthorizationFilter
    {
        //When User ID is not availale or removed from session,
        // it will redirect to login page
        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            if (filterContext.HttpContext.Session.GetString("UserID") == null)
                filterContext.Result = new RedirectResult("~/Home/Login");
        }
        // Once we logout (session is cleared) then we can not go back to the previous screen
        // We must login to proceed further.
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers["Cache-Control"] = "no-cache,no - store, must - revalidate";
            context.HttpContext.Response.Headers["Expires"] = "-1";
            context.HttpContext.Response.Headers["Pragma"] = "no-cache";
            base.OnResultExecuting(context);
        }
    }
}




public class CheckAdmin : ActionFilterAttribute, IAuthorizationFilter
{
    //When User ID is not availale or removed from session,
    // it will redirect to login page
    public void OnAuthorization(AuthorizationFilterContext filterContext)
    {
        if (filterContext.HttpContext.Session.GetString("UserRole") != "Admin")
            filterContext.Result = new RedirectResult("~/");
        //redirect at login page
    }
    // Once we logout (session is cleared) then we can not go back to the

    // We must login to proceed further.
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        context.HttpContext.Response.Headers["Cache-Control"] = "no-cache,no - store, must - revalidate";
        context.HttpContext.Response.Headers["Expires"] = "-1";
        context.HttpContext.Response.Headers["Pragma"] = "no-cache";
        base.OnResultExecuting(context);
    }
}