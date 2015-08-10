using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;


namespace LeadManagement.Infrastructure.Identity
{
    public class LMIdentityDBContext : IdentityDbContext<LMUser>
    {
        public LMIdentityDBContext()
            : base("LeadManagementIdentityDb") {
                Database.SetInitializer<LMIdentityDBContext>(new
                LMIdentityDBInitializer());
        }
        public static LMIdentityDBContext Create()
        {
            return new LMIdentityDBContext();
        }
    }
}