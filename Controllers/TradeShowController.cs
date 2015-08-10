using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeadManagement.Models;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using LeadManagement.Infrastructure.Identity;

namespace LeadManagement.Controllers
{
    public class TradeShowController : Controller
    {
         // GET: TradeShow
       IRepository repo;
        public TradeShowController(IRepository repoImpl)
        {
            repo = repoImpl;
        }

        public ActionResult Index()
        {
            return View(repo.TradeShows);
        }

     
        public async Task<ActionResult> DeleteTradeShow(int id)
        {
            await repo.DeleteTradShowsAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> SaveTradeShow(TradeShows TradeShow)
        {
            await repo.SaveTradshowAsync(TradeShow);
            return RedirectToAction("Index");
        }


        public async Task<ActionResult> SignIn()
        {
            IAuthenticationManager authMgr = HttpContext.GetOwinContext().Authentication;
            LMUserManager userMrg =
                HttpContext.GetOwinContext().GetUserManager<LMUserManager>();
            
            LMUser user = await userMrg.FindAsync("Admin", "secret");
            authMgr.SignIn(await userMrg.CreateIdentityAsync(user,
                DefaultAuthenticationTypes.ApplicationCookie));
            return RedirectToAction("Index");
        }

        public ActionResult SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}

    
    
