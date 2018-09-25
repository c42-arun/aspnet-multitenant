using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApp.Controllers
{
    public class MultiTenantControllerAllowAttribute : ActionFilterAttribute
    {
        private readonly List<string> _tenantList;

        public MultiTenantControllerAllowAttribute(string confArray)
        {
            _tenantList = confArray.ToLower().Split(',').ToList();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var controller = (MultiTenantMvcController) actionContext.ControllerContext.Controller;

            if (controller.Tenant == null || !_tenantList.Contains(controller.Tenant.Name.ToLower()))
                throw new HttpException(404, "Tenant not found");

            base.OnActionExecuting(actionContext);
        }
    }
}