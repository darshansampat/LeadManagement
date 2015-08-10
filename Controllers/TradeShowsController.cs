using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LeadManagement.Models;
using System.Threading.Tasks;
namespace LeadManagement.Controllers
{
    public class TradeShowsController : ApiController
    {

        public TradeShowsController()
        {
            Repository = (IRepository)GlobalConfiguration.Configuration.
                DependencyResolver.GetService(typeof(IRepository));

            //Repository = new TradeShowsRepository;
        }

        
        public IHttpActionResult GetAll()
        {
            return Ok(Repository.TradeShows);
        }
        //public IEnumerable<TradeShows> GetTradeShows()
        //{
        //    return Repository.TradeShows;
        //}

        public IHttpActionResult GetTradeShows(int id)
        {
            TradeShows result = Repository.TradeShows.Where(p => p.Id == id).FirstOrDefault();
            return result == null
                ? (IHttpActionResult)BadRequest("No Trade Show Found") : Ok(result);
        }

  
        public async Task<IHttpActionResult> PostProduct(TradeShows TradeShows)
        {
            if (ModelState.IsValid)
            {
                await Repository.SaveTradshowAsync(TradeShows);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

      public async Task DeleteProduct(int id)
        {
            await Repository.DeleteTradShowsAsync(id);
        }

        private IRepository Repository { get; set; }
    }
}
