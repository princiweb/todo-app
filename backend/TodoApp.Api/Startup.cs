using System;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using Owin;
using TodoApp.Api.Security;
using TodoApp.Domain.Contracts.Services;
using ExceptionHandler = TodoApp.Api.Handlers.ExceptionHandler;

namespace TodoApp.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            var container = new UnityContainer();
            ResolveDependencies(container);
            config.DependencyResolver = new DependencyResolver(container);

            app.UseCors(CorsOptions.AllowAll);

            ConfigureWebApi(config);
            ConfigureOAuth(app, container.Resolve<IUsuarioService>());

            app.UseWebApi(config);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Services.Replace(typeof(IExceptionHandler), new ExceptionHandler());

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }

        public void ConfigureOAuth(IAppBuilder app, IUsuarioService usuarioService)
        {
            var OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new AuthorizationServerProvider(usuarioService)
            };

            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}