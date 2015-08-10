using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LeadManagement.Infrastructure;
using System.Net.Http.Formatting;

namespace LeadManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "ilsapi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.DependencyResolver = new NinjectResolver();

            config.Services.Replace(typeof(IContentNegotiator), new CustomNegotiator());

        }
    }
}
