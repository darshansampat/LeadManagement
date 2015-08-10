using Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using LeadManagement.Infrastructure.Identity;
using System;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(LeadManagement.IdentityConfig))]

namespace LeadManagement
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<LMIdentityDBContext>(
                LMIdentityDBContext.Create);
            app.CreatePerOwinContext<LMUserManager>(LMUserManager.Create);
            app.CreatePerOwinContext<LMRoleManager>(LMRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });

            app.UseOAuthBearerTokens(new OAuthAuthorizationServerOptions
            {
                Provider = new ILSAutorization(),
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Authenticate")
            });
        }
    }
}