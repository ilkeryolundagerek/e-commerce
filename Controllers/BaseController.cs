using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (checkAuth(context))
            {
                base.OnActionExecuting(context);
            }
            else
            {
                Response.Redirect("/error/page401");
            }
        }

        private bool checkAuth(ActionExecutingContext context)
        {
            bool isAreaDashboard = false;
            if (context.RouteData.Values["area"] != null)
            {
                isAreaDashboard = context.RouteData.Values["area"].ToString().ToLower().Equals("dashboard");
            }
            return User.Identity.IsAuthenticated ? User.IsInRole("Admin") || !isAreaDashboard : !isAreaDashboard;
            /*
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return true;
                }
                else
                {
                    if (isAreaDashboard)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else if (isAreaDashboard)
            {
                return false;
            }
            else
            {
                return true;
            }
            */
        }
    }
}
