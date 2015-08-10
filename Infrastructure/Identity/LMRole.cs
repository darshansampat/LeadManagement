using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LeadManagement.Infrastructure.Identity
{
    public class LMRole : IdentityRole
    {
        public LMRole() : base() { }
        public LMRole(string name) : base(name) { }
    }
}