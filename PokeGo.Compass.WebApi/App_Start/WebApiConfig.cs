using System.Web.Http;
using PokeGo.Compass.WebApi.Attributes;
using System.Web.Http.ExceptionHandling;

namespace PokeGo.Compass.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Add(config.Formatters.JsonFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new ValidateModelAttribute());
            config.Services.Replace(typeof(IExceptionHandler), new GlobalErrorHandlerAttribute());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
