using LiteSchool.Assembler;
using LiteSchool.Library.Structuremap;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using StructureMap;
using StructureMap.Web.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LiteSchool.Front
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IContainer container = Bootstrapper.Init(ServiceAccessMode.InProcess, new HttpContextLifecycle());
            StructureMapDependencyScope structureMapDependencyScope = new StructureMapDependencyScope(container);
            DependencyResolver.SetResolver(structureMapDependencyScope);
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            HttpContextLifecycle.DisposeAndClearAll();
        }
    }
}
