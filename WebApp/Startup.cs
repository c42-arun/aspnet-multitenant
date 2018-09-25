using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

[assembly: OwinStartup(typeof(WebApp.Startup))]

namespace WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Use(async (ctx, next) =>
            {
                Tenant tenant = GetTenantBasedOnUrl(ctx.Request.Uri.Host);
                if (tenant == null)
                {
                    throw new ApplicationException("tenant not found");
                }

                ctx.Environment.Add("MultiTenant", tenant);
                await next();
            });
        }

        private Tenant GetTenantBasedOnUrl(string urlhost)
        {
            if (string.IsNullOrEmpty(urlhost))
            {
                throw new ApplicationException("urlHost must be specified");
            }

            Tenant tenant;
            using (var context = new MultiTenantContext())
            {
                DbSet<Tenant> tenants = context.Tenants;

                tenant = tenants.FirstOrDefault(a => a.DomainName.ToLower().Equals(urlhost))
                            ?? tenants.FirstOrDefault(a => a.Default);                
            }

            return tenant;
        }
    }
}