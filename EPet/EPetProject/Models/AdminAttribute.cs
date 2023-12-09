using EPetProject.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EPetProject.Models
{
    public class AdminAttribute : AuthorizeAttribute
    {

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            clinic clinic = (clinic)httpContext.Session[SessionKeyManager.LoginKey];
            if (clinic.Verify > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/Login/Index");
            base.HandleUnauthorizedRequest(filterContext);
        }
    }
}