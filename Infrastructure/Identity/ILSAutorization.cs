﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;


namespace LeadManagement.Infrastructure.Identity
{
    public class ILSAutorization : OAuthAuthorizationServerProvider
    {
        public override async Task GrantResourceOwnerCredentials(
                OAuthGrantResourceOwnerCredentialsContext context)
        {

            LMUserManager storeUserMgr =
                context.OwinContext.Get<LMUserManager>("AspNet.Identity.Owin:"
                    + typeof(LMUserManager).AssemblyQualifiedName);

            LMUser user = await storeUserMgr.FindAsync(context.UserName,
                context.Password);
            if (user == null)
            {
                context.SetError("invalid_grant",
                    "The username or password is incorrect");
            }
            else
            {
                ClaimsIdentity ident = await storeUserMgr.CreateIdentityAsync(user,
                        "Custom");
                AuthenticationTicket ticket
                    = new AuthenticationTicket(ident, new AuthenticationProperties());
                context.Validated(ticket);
                context.Request.Context.Authentication.SignIn(ident);
            }
        }

        public override Task ValidateClientAuthentication(
                OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }
    }
}