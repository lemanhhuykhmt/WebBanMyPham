using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDoMyPham
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product Detail",
                url: "productdetail/{id}",
                defaults: new { controller = "Product", action = "DetailProduct", id = UrlParameter.Optional },
                namespaces: new string[] { "WebDoMyPham.Controllers" }
            );
            routes.MapRoute(
                name: "Category Detail",
                url: "categorydetail/{id}",
                defaults: new { controller = "Product", action = "DetailCategory", id = UrlParameter.Optional },
                namespaces: new string[] { "WebDoMyPham.Controllers" }
            );
            routes.MapRoute(
                name: "Cart",
                url: "add-cart",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new string[] { "WebDoMyPham.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "WebDoMyPham.Controllers" }
            );
        }
    }
}
