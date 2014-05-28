using System;
using System.Web.Mvc;

namespace WEB_BASE.Helper
{
    public static class HtmlHelperExtends
    {
        public static string MakeActiveClass(this UrlHelper urlHelper, string controller, string action)
        {
            string result = "active";

            string controllerName = urlHelper.RequestContext.RouteData.Values["controller"].ToString();
            string actionName = urlHelper.RequestContext.RouteData.Values["action"].ToString();

            if (!(controllerName.Equals(controller, StringComparison.OrdinalIgnoreCase) && actionName.Equals(action, StringComparison.OrdinalIgnoreCase)))
            {
                result = null;
            }

            return result;
        }
    }
}