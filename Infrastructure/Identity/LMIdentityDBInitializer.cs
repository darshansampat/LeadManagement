using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;


namespace LeadManagement.Infrastructure.Identity
{
    public class LMIdentityDBInitializer : CreateDatabaseIfNotExists<LMIdentityDBContext>
    {
        protected override void Seed(LMIdentityDBContext context)
        {

            LMUserManager userMgr =
                new LMUserManager(new UserStore<LMUser>(context));
            LMRoleManager roleMgr =
                new LMRoleManager(new RoleStore<LMRole>(context));
        
            string roleName = "Administrators";
            string userName = "Admin";
            string password = "secret";
            string email = "admin@example.com";

            
            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new LMRole(roleName));
            }

            LMUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new LMUser
                {
                    UserName = userName,
                    Email = email
                }, password);
                user = userMgr.FindByName(userName);
            }

            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }

            base.Seed(context);
        }
    }
}