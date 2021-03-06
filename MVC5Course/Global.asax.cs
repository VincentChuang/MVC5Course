﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC5Course {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //移除 視圖引擎，為了移除 aspx 視窗引擎
            ViewEngines.Engines.Clear();
            //加載 Razor 視圖引擎
            ViewEngines.Engines.Add(new RazorViewEngine());

            //54 設定 ASP.NET Web APi 強制回應 JSON 格式
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

        }
    }
}
