﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShopNuocHoaTMD
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Topic",
                url: "topic/{alias}-{id}",
                defaults: new { controller = "Product", action = "ProductTopic", id = UrlParameter.Optional },
                namespaces: new[] { "ShopNuocHoaTMD.Controllers" }
            );
            routes.MapRoute(
                name: "Product",
                url: "product",
                defaults: new { controller = "Product", action = "Index", alias = UrlParameter.Optional },
                namespaces: new[] { "ShopNuocHoaTMD.Controllers" }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "ShopNuocHoaTMD.Controllers" }
            );
        }
    }
}
