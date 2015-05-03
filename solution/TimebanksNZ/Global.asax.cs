using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Timebanks.NZ.DAL.MySqlDb;
using Timebanks.NZ.DAL.MySqlDb.AutoMapper;

namespace TimebanksNZ
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // TODO NJ: Find a better way to do this once IoC in place
            AutomapperMySqlConfiguration.Configure();
        }
    }
}
