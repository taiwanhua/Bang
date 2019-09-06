using BangBang.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BangBang
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //資料庫初始化，用之前先關閉資料庫連接
            Database.SetInitializer<DataDbContext>(new DatabaseInitalizer());
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
