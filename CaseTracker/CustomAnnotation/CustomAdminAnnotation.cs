using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CaseTracker.CustomAnnotation
{
    public class CustomAdminAnnotation
    {
        public class YourCustomAuthorize : AuthorizeAttribute
        {
            public override void OnAuthorization(AuthorizationContext filterContext)
            {
                // If they are authorized, handle accordingly
                if (this.AuthorizeCore(filterContext.HttpContext))
                {
                    base.OnAuthorization(filterContext);
                }
                else
                {
                    // Otherwise redirect to your specific authorized area
                    filterContext.Result = new RedirectResult("~/Home/Unauthorized");
                }
            }
        }
    }
}