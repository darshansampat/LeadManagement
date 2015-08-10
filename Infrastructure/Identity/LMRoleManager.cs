using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace LeadManagement.Infrastructure.Identity
{
    public class LMRoleManager : RoleManager<LMRole>
    {

        public LMRoleManager(RoleStore<LMRole> store) : base(store) { }

        public static LMRoleManager Create(
                IdentityFactoryOptions<LMRoleManager> options,
                IOwinContext context)
        {
            return new LMRoleManager(new
                RoleStore<LMRole>(context.Get<LMIdentityDBContext>()));
        }

    }
}
