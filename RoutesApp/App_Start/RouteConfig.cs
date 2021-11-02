using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RoutesApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Home/Index/12");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }, constraints: new { controller = "^H.*", id = @"\d{2}",
                //    httpMethod = new HttpMethodConstraint("GET")
                //}); //12 34 56
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional 
                //, constraints: new
                //{
                //    id = @"\d{2}", myConstraint = new CustomConstraint("/Home/Index/12")
                });


            //routes.MapRoute(
            //    name: "Default2",
            //    url: "R{controller}/{action}/{id}",
            //    defaults: new { id = UrlParameter.Optional });
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}/{*catchall}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            //routes.MapRoute(
            //    name: "Default",
            //    //url: "Ru/{controller}/{action}/{id}",
            //    url: "My/Account",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }

            //defaults: new { id = UrlParameter.Optional }
            //);
            //Route newRoute = new Route("{controller}/{action}", new MvcRouteHandler());
            //routes.Add(newRoute);


        }
        public class CustomConstraint : IRouteConstraint
        {
            private string uri;
            public CustomConstraint(string uri)
            {
                this.uri = uri;
            }
            public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
            {
                return !(uri == httpContext.Request.Url.AbsolutePath);
            }
        }
    }
}
