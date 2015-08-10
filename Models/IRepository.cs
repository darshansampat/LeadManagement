using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadManagement.Models
{
    public interface IRepository
    {

        IEnumerable<TradeShows> TradeShows { get; }
        Task<int> SaveTradshowAsync(TradeShows TradeShows);
        Task<TradeShows> DeleteTradShowsAsync(int TradeShowID);

    }
}
