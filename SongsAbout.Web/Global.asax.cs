﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SongsAbout.Web;
using SongsAbout.Web.Models;
using System.Data.Entity;

namespace SongsAbout.Web
{
    public class MvcApplication : HttpApplication
    {
        public void Application_Start()
        {
            Database.SetInitializer(new EntityDbInitializer());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
