﻿using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Dalyan.WebApi.Providers;
using System;
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using Dalyan.WebApi.Security;

[assembly: OwinStartup(typeof(Dalyan.WebApi.Startup))]
namespace Dalyan.WebApi
{
    public class Startup
    {
        public static Container Container;
        public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }
        public static OAuthAuthorizationServerOptions OAuthServerOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {

            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            Container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            Dalyan.Service.Bootstrap.Bootstrapper.Setup(Container);
            Container.RegisterSingleton<Entities.Interfaces.IUserContext, UserContext>();
            Container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(Container);
            
            HttpConfiguration config = GlobalConfiguration.Configuration;
            
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
            ConfigureOAuth(app,Container);
            app.UseWebApi(config);
        }

        public void ConfigureOAuth(IAppBuilder app,Container container)
        {
            OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new AuthorizationServerProvider(container)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(OAuthBearerOptions);
        }
    }
}