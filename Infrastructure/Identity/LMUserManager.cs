using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace LeadManagement.Infrastructure.Identity
{
    public class LMUserManager : UserManager<LMUser>
    {

        public LMUserManager(IUserStore<LMUser> store)
            : base(store) { }

        public static LMUserManager Create(
                IdentityFactoryOptions<LMUserManager> options,
                IOwinContext context)
        {

            LMIdentityDBContext dbContext = context.Get<LMIdentityDBContext>();
            LMUserManager manager =
                new LMUserManager(new UserStore<LMUser>(dbContext));
            return manager;
        }
    }
}
