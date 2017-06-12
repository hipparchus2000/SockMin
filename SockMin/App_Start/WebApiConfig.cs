using System.Web.Http;

namespace SockMin
{
    public class WebApiConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{resource}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }

    }
}