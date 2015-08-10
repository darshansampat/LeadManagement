using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LeadManagement.Models
{
    public class TradeShowsDBContext : DbContext {
        public TradeShowsDBContext()
            : base("LeadManagement") {
                Database.SetInitializer<TradeShowsDBContext>(new TradeShowsDbInitializer());
        }
        public DbSet<TradeShows> TradeShows { get; set; }
    }
}