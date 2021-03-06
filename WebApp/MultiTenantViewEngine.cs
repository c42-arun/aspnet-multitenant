﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Controllers;

namespace WebApp
{
    public class MultiTenantViewEngine : RazorViewEngine
    {
        public MultiTenantViewEngine()
        {
            ViewLocationFormats = new []
            {
                "~/Views/%1/{1}/{0}.cshtml",
                "~/Views/{1}/{0}.cshtml",
                "~/Views/%1/Shared/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };

            PartialViewLocationFormats = ViewLocationFormats;
            MasterLocationFormats = ViewLocationFormats;

            AreaMasterLocationFormats = new[]
            {
                "~/Areas/%1/Views/{1}/{0}.cshtml",
                "~/Areas/%1/Views/{1}/{0}.vbhtml",
                "~/Areas/%1/Views/Shared/{0}.cshtml",
                "~/Areas/%1/Views/Shared/{0}.vbhtml",
            };

            AreaPartialViewLocationFormats = AreaMasterLocationFormats;
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            var controller = controllerContext.Controller as MultiTenantMvcController;

            Debug.Assert(controller != null, "PassedController != null");

            return base.CreateView(controllerContext,
                viewPath.Replace("%1", controller.Tenant.Name),
                masterPath.Replace("%1", controller.Tenant.Name));
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            var controller = controllerContext.Controller as MultiTenantMvcController;

            Debug.Assert(controller != null, "PassedController != null");

            return base.CreatePartialView(controllerContext, partialPath.Replace("%1", controller.Tenant.Name));
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            var controller = controllerContext.Controller as MultiTenantMvcController;

            Debug.Assert(controller != null, "PassedController != null");

            return base.FileExists(controllerContext, virtualPath.Replace("%1", controller.Tenant.Name));
        }
    }
}