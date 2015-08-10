using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;


namespace LeadManagement.Models
{
    public class TradeshowsRepository :IRepository
    {
        private TradeShowsDBContext context = new TradeShowsDBContext();
        public IEnumerable<TradeShows> TradeShows
        {
            get { return context.TradeShows; }
        }

        public async Task<int> SaveTradshowAsync(TradeShows TradeShows)
        {
            if (TradeShows.Id == 0)
            {
                context.TradeShows.Add(TradeShows);
            }
            else
            {
                TradeShows dbEntry = context.TradeShows.Find(TradeShows.Id);
                if (dbEntry != null)
                {
                    dbEntry.TradeShowName = TradeShows.TradeShowName;
                    dbEntry.LeadName = TradeShows.LeadName;
                    dbEntry.EmailAddress = TradeShows.EmailAddress;
                    dbEntry.Telepohone = TradeShows.Telepohone;
                  
                }
            }
            return await context.SaveChangesAsync();
        }

        public async Task<TradeShows> DeleteTradShowsAsync(int TradeShowID)
        {
            TradeShows dbEntry = context.TradeShows.Find(TradeShowID);
            if (dbEntry != null)
            {
                context.TradeShows.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }

    }
}