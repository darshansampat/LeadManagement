using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace LeadManagement.Models
{
    public class TradeShowsDbInitializer : DropCreateDatabaseIfModelChanges<TradeShowsDBContext>
    {
        protected override void Seed(TradeShowsDBContext context)
        {
            new List<TradeShows>
            {
                new TradeShows() {Id = 1, TradeShowName = "MRO Europe", LeadName= "Darshan", EmailAddress = "dsampat@ilsmart.com", Telepohone = "901-409-5889"},
                new TradeShows() {Id = 2, TradeShowName = "USA Europe", LeadName= "Jigna",EmailAddress = "jsampat@ilsmart.com", Telepohone = "901-409-5889"}
            }.ForEach (TradeShows => context.TradeShows.Add(TradeShows));

        }

    }
}
