using Common;
using Common.Model;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Common
{
    public class HasPermission : AuthorizeAttribute
    {
        public string PermissionName { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var curentSession = (UserSession)HttpContext.Current.Session[CommonConstants.UserSession];
            if (curentSession == null) return false;
            return curentSession.LstPermission.Contains(PermissionName.ToLower());
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}